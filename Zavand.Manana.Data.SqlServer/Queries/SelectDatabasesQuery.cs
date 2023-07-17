namespace Zavand.Manana.Data.SqlServer.Queries;

public class SelectDatabasesQuery : StorageQuery
{
    public DataObjects.Database[] Databases { get; private set; }

    public override string GetSqlQuery()
    {
        return "select database_id,name,create_date,collation_name,physical_database_name from master.sys.databases";
    }

    public override void Read(Queue<ResultSet> resultSets)
    {
        var databases = new List<DataObjects.Database>();
        ColumnValueReader.ReadAll(resultSets.Dequeue(), (columns, r) =>
        {
            var e = new DataObjects.Database
            {
                Id = r.Get<int>("database_id", columns, Errors),
                Name = r.Get<string>("name", columns, Errors),
                CreateDate = r.Get<DateTime>("create_date", columns, Errors),
                CollationName = r.Get<string>("collation_name", columns, Errors),
                PhysicalDatabaseName = r.Get<string>("physical_database_name", columns, Errors)
            };
            databases.Add(e);
        });
        Databases = databases.ToArray();
    }
}