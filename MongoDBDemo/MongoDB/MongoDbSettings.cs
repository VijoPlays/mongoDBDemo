namespace MongoDBDemo.MongoDB;

public class MongoDbSettings(string connectionString, string databaseName)
{
    public string ConnectionString { get; init; } = connectionString;
    public string DatabaseName { get; init; } = databaseName;
}