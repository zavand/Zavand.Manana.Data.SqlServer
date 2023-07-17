namespace Zavand.Manana.Data.SqlServer;

public interface ISqlServerTable
{
    string GetDatabaseName();
    string GetTableName();
    string GetSchemaName();
}