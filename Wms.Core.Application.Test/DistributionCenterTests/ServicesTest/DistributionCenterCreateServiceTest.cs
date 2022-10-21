using ErrorOr;
using Moq;
using Moq.AutoMock;
using Wms.Core.Application.DistributionCenterUseCases.Errors;
using Wms.Core.Application.DistributionCenterUseCases.Services.Create;
using Wms.Core.Domain.Entities.Entity;
using Wms.Core.Infrastructure.Interfaces.EntityRepositoryInterface;
using Xunit;
// ReSharper disable All

namespace Wms.Core.Application.Test.DistributionCenterTests.ServicesTest;

[Collection(nameof(DistributionCenterFixtureCollection))]
public class DistributionCenterCreateServiceTest
{
    private readonly DistributionCenterFixture _fixture;
    private readonly AutoMocker _mocker = new AutoMocker();
    private readonly DistributionCenterCreateService _service;

    public DistributionCenterCreateServiceTest(DistributionCenterFixture fixture)
    {
        _fixture = fixture;
        _service = _mocker.CreateInstance<DistributionCenterCreateService>();
    }

    [Fact(DisplayName = "Deve retornar um erro, o documento informado ja existe")]
    [Trait("DistributionCenterCreateServices", "Simulando conflito de dados")]
    public async void ValidCreateDistributionCenter_DocumentExist_MustReturnError()
    {
        // Arrange
        DistributionCenter cd = _fixture.GenerateDistributionCenter();
        _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByDocument(cd.Document))
            .ReturnsAsync(cd);

        // Act
        Error? isValid = await _service.ValidCreateDistributionCenter(cd);

        // Assert
        Assert.Equal(isValid, DistributionCenterValidationErrors.DocumentIsAlreadyBeingUsed);
       _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByDocument(cd.Document), Times.Once);
    }

    [Fact(DisplayName = "Deve retornar um erro, o codigo informado ja existe")]
    [Trait("DistributionCenterCreateServices", "Simulando conflito de dados")]
    public async void ValidCreateDistributionCenter_CodeExist_MustReturnError()
    {
        // Arrange
        DistributionCenter cd = _fixture.GenerateDistributionCenter();
       _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByCode(cd.Code))
            .ReturnsAsync(cd);

        // Act
        Error? isValid = await _service.ValidCreateDistributionCenter(cd);

        // Assert
        Assert.Equal(isValid, DistributionCenterValidationErrors.CodeIsAlreadyBeingUsed);
       _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByCode(cd.Code), Times.Once);
    }

    [Fact(DisplayName = "Nao deve retornar erro, o codigo utilizado nao existe")]
    [Trait("DistributionCenterCreateServices", "Simulando açao bem sucedida")]
    public async void ValidCreateDistributionCenter_CodeDoesNotExist_MustReturnNull()
    {
        // Arrange
        DistributionCenter cd = _fixture.GenerateDistributionCenter();
       _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByCode(cd.Code)).ReturnsAsync(null as DistributionCenter);

        // Act
        Error? isValid = await _service.ValidCreateDistributionCenter(cd);

        // Assert
        Assert.Null(isValid);
       _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByCode(cd.Code), Times.Once);
    }

    [Fact(DisplayName = "Nao deve retornar erro, o documento utilizado nao existe")]
    [Trait("DistributionCenterCreateServices", "Simulando açao bem sucedida")]
    public async void ValidCreateDistributionCenter_DocumentDoesNotExist_MustReturnNull()
    {
        // Arrange
        DistributionCenter cd = _fixture.GenerateDistributionCenter();
       _mocker.GetMock<IDistributionCenterRepository>()
            .Setup(repository => repository.GetByDocument(cd.Document));

        // Act
        Error? isValid = await _service.ValidCreateDistributionCenter(cd);

        // Assert
        Assert.Null(isValid);
       _mocker.GetMock<IDistributionCenterRepository>()
            .Verify(repository => repository.GetByDocument(cd.Document), Times.Once);
    }
}