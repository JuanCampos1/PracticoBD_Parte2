using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace aplicación1
{
    public class AccesoDatos
    {
        private IMongoDatabase database;

        public AccesoDatos(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<BsonDocument> ObtenerColeccion(string collectionName)
        {
            return database.GetCollection<BsonDocument>(collectionName);
        }
    
    }
    
    public class PracticoDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("personas")]
        public List<Persona> Personas { get; set; }
    }
    public class Persona
    {
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("edad")]
        public int Edad { get; set; }

        [BsonElement("carrera")]
        public string Carrera { get; set; }

        [BsonElement("semestre")]
        public int Semestre { get; set; }

        [BsonElement("rol")]
        public string Rol { get; set; }

        [BsonElement("cedula")]
        public string Cedula { get; set; }
        
        [BsonElement("especialidad")]
        public string Especialidad { get; set; }
    }

}