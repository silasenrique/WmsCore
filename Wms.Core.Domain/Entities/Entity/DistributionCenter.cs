using Wms.Core.Domain.Common.Models;

namespace Wms.Core.Domain.Entities.Entity;

public class DistributionCenter : Audit
{
    public DistributionCenter(string code)
    {
        Code = code;
    }

    public DistributionCenter(string code, string name, string document)
    {
        Code = code;
        Name = name;
        Document = document;
    }

    public DistributionCenter(int id, string code, string name, string document)
    {
        Id = id;
        Code = code;
        Name = name;
        Document = document;
    }

    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }

    public void ChangeCode(string code)
    {
        Code = code;
    }

    public void ChangeName(string name)
    {
        Name = name;
    }

    public void ChangeDocument(string document)
    {
        Document = document;
    }
}