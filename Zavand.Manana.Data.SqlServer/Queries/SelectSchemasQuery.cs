namespace Zavand.Manana.Data.SqlServer.Queries;

public class SelectSchemasQuery : StorageQuery
{
    public DataObjects.Schemata[] Schemas { get; private set; }

    public override string GetSqlQuery()
    {
        return "select * from INFORMATION_SCHEMA.SCHEMATA";
    }

    public override void Read(Queue<ResultSet> resultSets)
    {
        var schemas = new List<DataObjects.Schemata>();
        ColumnValueReader.ReadAll(resultSets.Dequeue(), (columns, r) =>
        {
            var e = new DataObjects.Schemata
            {
                CatalogName = r.Get<string>("CATALOG_NAME", columns, Errors),
                SchemaName = r.Get<string>("SCHEMA_NAME", columns, Errors),
                SchemaOwner = r.Get<string>("SCHEMA_OWNER", columns, Errors),
                DefaultCharacterSetCatalog = r.Get<string>("DEFAULT_CHARACTER_SET_CATALOG", columns, Errors),
                DefaultCharacterSetSchema = r.Get<string>("DEFAULT_CHARACTER_SET_SCHEMA", columns, Errors),
                DefaultCharacterSetName = r.Get<string>("DEFAULT_CHARACTER_SET_NAME", columns, Errors),
            };
            schemas.Add(e);
        });
        Schemas = schemas.ToArray();
    }
}