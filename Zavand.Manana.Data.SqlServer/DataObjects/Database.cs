namespace Zavand.Manana.Data.SqlServer.DataObjects;

public class Database
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public string CollationName { get; set; }
    public string PhysicalDatabaseName { get; set; }

    public override string ToString()
    {
        return $"{Name} | {Id} | {CreateDate} | {CollationName}";
    }
}