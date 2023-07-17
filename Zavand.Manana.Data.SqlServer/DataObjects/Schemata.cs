namespace Zavand.Manana.Data.SqlServer.DataObjects;

public class Schemata
{
    public string CatalogName { get; set; }
    public string SchemaName { get; set; }
    public string SchemaOwner { get; set; }
    public string DefaultCharacterSetCatalog { get; set; }
    public string DefaultCharacterSetSchema { get; set; }
    public string DefaultCharacterSetName { get; set; }

    public override string ToString()
    {
        return $"{CatalogName}.{SchemaName}";
    }
}