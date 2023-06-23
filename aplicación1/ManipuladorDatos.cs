using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace aplicación1
{
    public class ManipuladorDatos
    {
        private IMongoCollection<PracticoDB> collection;

        public ManipuladorDatos(IMongoCollection<PracticoDB> collection)
        {
            this.collection = collection;
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            var filter = Builders<PracticoDB>.Filter.Empty;
            var projection = Builders<PracticoDB>.Projection
                .Exclude("_id")
                .Exclude("className");
            var personas = collection.Find(filter).Project<PracticoDB>(projection).FirstOrDefault()?.Personas;

            if (personas == null)
            {
                return new List<Persona>();
            }

            return personas;
        }



        public List<string> ObtenerCedulasPorRol(string rol)
        {
            var filter = Builders<PracticoDB>.Filter.Eq("rol", rol);
            var projection = Builders<PracticoDB>.Projection.Include("cedula");
            var personas = collection.Find(filter).Project(projection).ToList();

            var cedulas = new List<string>();
            foreach (var persona in personas)
            {
                var cedula = persona.GetValue("cedula").AsString;
                cedulas.Add(cedula);
            }

            return cedulas;
        }

        public bool CambiarRolPersona(string cedula, string nuevoRol)
        {
            var filter = Builders<PracticoDB>.Filter.Eq("cedula", cedula);
            var update = Builders<PracticoDB>.Update.Set("rol", nuevoRol);

            var result = collection.UpdateOne(filter, update);
            return result.ModifiedCount > 0;
        }

        public bool EliminarPersona(string cedula)
        {
            var filter = Builders<PracticoDB>.Filter.Eq("cedula", cedula);

            var result = collection.DeleteOne(filter);
            return result.DeletedCount > 0;
        }
    }
}