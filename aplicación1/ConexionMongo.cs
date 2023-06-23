using MongoDB.Driver;

namespace aplicación1;

public class ConexionMongo
{
    private const string connectionString = "mongodb://basededatos1:iPvRpmhtJQRwmCas8RON5GoOytZUrFay1UoB2AeCJCznoAGWYcry7fSWFSfxgvvqR8QsBvvJFkgaACDbToHIvg%3D%3D@basededatos1.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@basededatos1@";
    private const string databaseName = "bd_2023";

    private IMongoDatabase database;

    public ConexionMongo()
    {
        MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
        MongoClient client = new MongoClient(settings);
        database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<PracticoDB> GetPersonasCollection()
    {
        return database.GetCollection<PracticoDB>("personas_J_Campos");
    }
}