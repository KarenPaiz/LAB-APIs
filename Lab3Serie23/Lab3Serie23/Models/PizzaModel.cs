using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lab3Serie23.Models
{
    public class PizzaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("Name")]
        public string NombrePizza { get; set; }

        public string Descripcion { get; set; }

        public string[] Ingredientes { get; set; }

        public string Masa { get; set; }
        public string Tamano { get; set; }
        public int Porciones { get; set; }
        public bool Queso { get; set; }
    }
}
