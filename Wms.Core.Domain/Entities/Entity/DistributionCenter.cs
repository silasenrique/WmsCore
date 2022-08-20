namespace Wms.Core.Domain.Entities.Entity;

public class DistributionCenter
{
    public DistributionCenter(int id)
    {
        Id = id;
    }

    public DistributionCenter(string code, string name, string document)
    {
        Code = code;
        Name = name;
        Document = document;

        CreationDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        LastChangeDate = CreationDate;
    }

    public DistributionCenter(int id, string code, string name, string document)
    {
        Id = id;
        Code = code;
        Name = name;
        Document = document;
        LastChangeDate = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public long CreationDate { get; set; }
    public long LastChangeDate { get; set; }
}