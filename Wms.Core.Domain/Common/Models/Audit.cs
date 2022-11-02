namespace Wms.Core.Domain.Common.Models;

public abstract class Audit
{
    public DateTime CreationDate { get; private set; }
    public DateTime LastChangeDate { get; private set; }

    public void CreateRecord()
    {
        CreationDate = DateTime.Now.ToLocalTime();
        LastChangeDate = CreationDate;
    }

    public void UpdateRecord()
    {
        LastChangeDate = DateTime.Now.ToLocalTime();
    }
}