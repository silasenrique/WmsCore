using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions.Brazil;
using Moq.AutoMock;
using Wms.Core.Application.DistributionCenterUseCases.Services.Create;
using Wms.Core.Application.DistributionCenterUseCases.Services.Update;
using Wms.Core.Domain.Entities.Entity;
using Xunit;
// ReSharper disable All

namespace Wms.Core.Application.Test.DistributionCenterTests.ServicesTest;

[CollectionDefinition(nameof(DistributionCenterFixtureCollection))]
public class DistributionCenterFixtureCollection : ICollectionFixture<DistributionCenterFixture> { }

public class DistributionCenterFixture : IDisposable
{
    private static IEnumerable<DistributionCenter> GenerateDistributionCenter(int amount)
    {
        Faker<DistributionCenter> distributionCenter = new Faker<DistributionCenter>("pt_BR")
            .CustomInstantiator(f => new DistributionCenter(
                f.Hacker.Abbreviation(), 
                f.Company.CompanyName(), 
                f.Company.Cnpj()));

        return distributionCenter.Generate(amount);
    }
    
    public DistributionCenter GenerateDistributionCenter()
    {
        return GenerateDistributionCenter(1).FirstOrDefault()!;
    }

    public DistributionCenter GenerateDistributionCenterUpdate()
    {
        Faker<DistributionCenter> cd = new Faker<DistributionCenter>("pt_BR")
            .CustomInstantiator(f => new DistributionCenter(
                f.Random.Number(1, 100),
                f.Hacker.Abbreviation(), 
                f.Company.CompanyName(), 
                f.Company.Cnpj()));

        return cd;
    }

    public void Dispose() { }
}