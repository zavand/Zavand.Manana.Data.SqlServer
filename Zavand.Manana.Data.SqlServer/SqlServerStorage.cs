using System.Data.Common;
using System.Data.SqlClient;

namespace Zavand.Manana.Data.SqlServer;

public class SqlServerStorage : Storage
{
    public string DatabaseName { get; protected set; }

    public override void ChangeDatabase(string databaseName)
    {
        DatabaseName = databaseName;
        _connection.ChangeDatabase(DatabaseName);
    }

    public override async Task OpenAsync()
    {
        await base.OpenAsync();
        if (!String.IsNullOrEmpty(DatabaseName) && !_connection.Database.Equals(DatabaseName, StringComparison.CurrentCultureIgnoreCase))
            ChangeDatabase(DatabaseName);
    }

    protected override DbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    protected override DbCommand CreateCommand()
    {
        return new SqlCommand();
    }

    protected override void AddParameter(DbParameterCollection parameters, string parameterName, object value)
    {
        ((SqlParameterCollection)parameters).AddWithValue(parameterName, value);
    }
}