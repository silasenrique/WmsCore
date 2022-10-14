using System;
using Bogus;
using Bogus.Extensions.Brazil;
using Wms.Core.Domain.Entities.Entity;
using Xunit;

namespace Wms.Core.Application.Test.DistributionCenterTests.ServicesTest;

[CollectionDefinition(nameof(DistributionCenterFixtureCollection))]
public class DistributionCenterFixtureCollection : ICollectionFixture<DistributionCenterFixture> { }

public class DistributionCenterFixture : IDisposable
{
    public DistributionCenter GenerateValidDistributionCenter()
    {
        var fakerDistributionCenter = new Faker<DistributionCenter>("pt_BR")
            .CustomInstantiator(f => new DistributionCenter(f.Hacker.Abbreviation(), f.Company.CompanyName(), f.Company.Cnpj()));

        return fakerDistributionCenter;
    }
    
    public void Dispose()
    {
        
    }
}