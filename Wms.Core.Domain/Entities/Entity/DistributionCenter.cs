namespace Wms.Core.Domain.Entities.Entity;

public class DistributionCenter
{
    public DistributionCenter(int id)
    {
        Id = id;
    }

    public DistributionCenter(string? code, string? name, string? document)
    {
        Code = code;
        Name = name;
        Document = document;
    }

    public DistributionCenter(int id, string? code, string? name, string? document)
    {
        Id = id;
        Code = code;
        Name = name;
        Document = document;
    }

    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastChangeDate { get; set; }
}