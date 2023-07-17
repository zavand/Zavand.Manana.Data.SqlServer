namespace Zavand.Manana.Data.SqlServer;

public class SqlServerTable : ISqlServerTable
{
    private readonly string _tableName;
    private readonly string _schemaName;
    private readonly string _databaseName;

    public string GetDatabaseName() => _databaseName;

    public string GetTableName() => _tableName;

    public string GetSchemaName() => _schemaName;

    public SqlServerTable(string tableName, string schemaName, string databaseName)
    {
        _tableName = tableName;
        _schemaName = schemaName;
        _databaseName = databaseName;
    }
}