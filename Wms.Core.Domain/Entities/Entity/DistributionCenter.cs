namespace Wms.Core.Domain.Entities.Entity;

public class DistributionCenter
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

    public int Id { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public long CreationDate { get; private  set; }
    public long LastChangeDate { get; private set; }
}