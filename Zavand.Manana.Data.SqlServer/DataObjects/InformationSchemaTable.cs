namespace Zavand.Manana.Data.SqlServer.DataObjects;

public class InformationSchemaTable
{
    public string TableCatalog { get; set; }
    public string TableSchema { get; set; }
    public string TableName { get; set; }
    public string TableType { get; set; }
}