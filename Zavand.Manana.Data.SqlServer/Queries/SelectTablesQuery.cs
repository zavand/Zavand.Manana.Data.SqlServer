namespace Zavand.Manana.Data.SqlServer.Queries;

public class SelectTablesQuery:StorageQuery
{
    private readonly string _databaseName;

    public SelectTablesQuery(string databaseName)
    {
        _databaseName = databaseName;
    }

    public DataObjects.InformationSchemaTable[] Tables { get; set; }

    public override string GetSqlQuery()
    {
        return $"select * from INFORMATION_SCHEMA.TABLES where TABLE_CATALOG='{_databaseName}';";
    }

    public override void Read(Queue<ResultSet> resultSets)
    {
        var tables = new List<DataObjects.InformationSchemaTable>();
        ColumnValueReader.ReadAll(resultSets.Dequeue(), (columns, r) =>
        {
            var e = new DataObjects.InformationSchemaTable
            {
                     TableCatalog = r.Get<string>("TABLE_CATALOG", columns, Errors),
                     TableSchema = r.Get<string>("TABLE_SCHEMA", columns, Errors),
                     TableName = r.Get<string>("TABLE_NAME", columns, Errors),
                     TableType = r.Get<string>("TABLE_TYPE", columns, Errors),
            };
            tables.Add(e);
        });
        Tables = tables.ToArray();
    }
}