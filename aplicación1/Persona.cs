using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace aplicación1.Models
{
    public class Persona
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
}
