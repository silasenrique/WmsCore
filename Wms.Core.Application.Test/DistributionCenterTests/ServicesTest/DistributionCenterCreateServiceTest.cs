using ErrorOr;
using Moq;
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

    public DistributionCenterCreateServiceTest(DistributionCenterFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Valida se o codigo ja existe na base de dados")]
    [Trait("DistributionCenterServices", "Teste dos serviços do DistributionCenter")]
    public async void ValidCreateDistributionCenter_CodeNotExist_MustReturnNull()
    {
        // Arrange
        Mock<IDistributionCenterRepository> distributionCenterRepository = new Mock<IDistributionCenterRepository>();
        DistributionCenter distributionCenter = _fixture.GenerateValidDistributionCenter();
        DistributionCenterCreateService service = new(distributionCenterRepository.Object);

        // Act
        Error? isValid = await service.ValidCreateDistributionCenter(distributionCenter);

        // Assert
        Assert.Null(isValid);
        distributionCenterRepository.Verify(cd => cd.GetByCode(distributionCenter.Code));
    }
    
    public async void ValidCreateDistributionCenter_DocumentDoesNotExist_MustReturnNull()
    {
        Mock<IDistributionCenterRepository> distributionCenterRepository = new Mock<IDistributionCenterRepository>();
    }
}