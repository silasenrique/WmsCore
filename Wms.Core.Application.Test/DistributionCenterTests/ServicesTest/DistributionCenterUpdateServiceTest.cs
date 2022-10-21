using ErrorOr;
using Moq;
using Moq.AutoMock;
using Wms.Core.Application.DistributionCenterUseCases.Errors;
using Wms.Core.Application.DistributionCenterUseCases.Services.Update;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Xunit;
// ReSharper disable All

namespace Wms.Core.Application.Test.DistributionCenterTests.ServicesTest;

[Collection(nameof(DistributionCenterFixtureCollection))]
public class DistributionCenterUpdateServiceTest
{
    private readonly DistributionCenterFixture _fixture;
    private readonly AutoMocker _mocker = new AutoMocker();
    private readonly DistributionCenterUpdateService _service;

    public DistributionCenterUpdateServiceTest(DistributionCenterFixture fixture)
    {
        _fixture = fixture;
        _service = _mocker.CreateInstance<DistributionCenterUpdateService>();
    }

    [Fact(DisplayName = "Deve retornar um erro, id nao existe")]
    [Trait("DistributionCenterUpdateService", "Simulando conflito de dados")]
    public async void ValidateUpdateDistributionCenter_IdDoesNotExist_MustReturnError()
    {
        // Arrange
        DistributionCenter cd = _fixture.GenerateDistributionCenterUpdate();
        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(cd.Id))
            .ReturnsAsync((DistributionCenter)null);
        
        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(cd);

        // Assert
        Assert.Equal(isValid, DistributionCenterValidationErrors.IdNotFound);
        _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetById(cd.Id), Times.Once);
    }

    [Fact(DisplayName = "Deve retornar um erro, esta trocando o documento e colocando um que ja esta sendo utilizado")]
    [Trait("DistributionCenterUpdateService", "Simulando conflito de dados")]
    public async void ValidateUpdateDistributionCenter_DuplicateDocument_MustReturnError()
    {
        // Arrange
        DistributionCenter originalCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter changedCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter alreadyExistingCd = _fixture.GenerateDistributionCenterUpdate();
        
        changedCd = new DistributionCenter(originalCd.Id, originalCd.Code, changedCd.Document, originalCd.Name);
        alreadyExistingCd = new DistributionCenter(alreadyExistingCd.Id, alreadyExistingCd.Code, alreadyExistingCd.Name, changedCd.Document);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(changedCd.Id))
            .ReturnsAsync(originalCd);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByDocument(changedCd.Document))
            .ReturnsAsync(alreadyExistingCd);

        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(changedCd);

        // Assert
        Assert.Equal(isValid, DistributionCenterValidationErrors.DocumentIsAlreadyBeingUsed);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByDocument(changedCd.Document), Times.Once);
    }
    
    [Fact(DisplayName = "Deve retornar um erro, esta trocando o codigo e colocando um que ja esta sendo utilizado")]
    [Trait("DistributionCenterUpdateService", "Simulando conflito de dados")]
    public async void ValidateUpdateDistributionCenter_DuplicateCode_MustReturnError()
    {
        // Arrange
        DistributionCenter originalCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter changedCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter alreadyExistingCd = _fixture.GenerateDistributionCenterUpdate();
        
        changedCd = new DistributionCenter(originalCd.Id, changedCd.Code, originalCd.Document, originalCd.Name);
        alreadyExistingCd = new DistributionCenter(alreadyExistingCd.Id, changedCd.Code, alreadyExistingCd.Name, alreadyExistingCd.Document);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(changedCd.Id))
            .ReturnsAsync(originalCd);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByCode(changedCd.Code))
            .ReturnsAsync(alreadyExistingCd);

        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(changedCd);

        // Assert
        Assert.Equal(isValid, DistributionCenterValidationErrors.CodeIsAlreadyBeingUsed);
        
        _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByCode(changedCd.Code), Times.Once);
    }

    [Fact(DisplayName = "Alterando o codigo para um codigo valido")]
    [Trait("DistributionCenterUpdateService", "Simulando açao bem sucedida")]
    public async void ValidateUpdateDistributionCenter_NewValidCode_MustReturnNull()
    {
        // Arrange
        DistributionCenter originalCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter changedCd = _fixture.GenerateDistributionCenterUpdate();
        
        changedCd = new DistributionCenter(originalCd.Id, changedCd.Code, originalCd.Name, originalCd.Document);
        
        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(changedCd.Id))
            .ReturnsAsync(originalCd);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByCode(changedCd.Code))
            .ReturnsAsync((DistributionCenter)null);
        
        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(changedCd);

        // Assert
        Assert.Null(isValid);
        _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByCode(changedCd.Code), Times.Once);
    }
    
    [Fact(DisplayName = "Alterando o codigo para um codigo valido")]
    [Trait("DistributionCenterUpdateService", "Simulando açao bem sucedida")]
    public async void ValidateUpdateDistributionCenter_NewValidDocument_MustReturnNull()
    {
        // Arrange
        DistributionCenter originalCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter changedCd = _fixture.GenerateDistributionCenterUpdate();
        
        changedCd = new DistributionCenter(originalCd.Id, originalCd.Code, originalCd.Name, changedCd.Document);
        
        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(changedCd.Id))
            .ReturnsAsync(originalCd);

        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByDocument(changedCd.Document))
            .ReturnsAsync((DistributionCenter)null);
        
        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(changedCd);

        // Assert
        Assert.Null(isValid);
        _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByDocument(changedCd.Document), Times.Once);
    }
    
    [Fact(DisplayName = "Alterando apenas a descriçao, nao deve retornar erro algum")]
    [Trait("DistributionCenterUpdateService", "Simulando açao bem sucedida")]
    public async void ValidateUpdateDistributionCenter_ChangeNameDesc_MustReturnNull()
    {
        // Arrange
        DistributionCenter originalCd = _fixture.GenerateDistributionCenterUpdate();
        DistributionCenter changedCd = _fixture.GenerateDistributionCenterUpdate();
        
        changedCd = new DistributionCenter(originalCd.Id, originalCd.Code, changedCd.Name, originalCd.Document);
        
        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetById(changedCd.Id))
            .ReturnsAsync(originalCd);

        // Act
        Error? isValid = await _service.ValidateUpdateDistributionCenter(changedCd);

        // Assert
        Assert.Null(isValid);
    }
}