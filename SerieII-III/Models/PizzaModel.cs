using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SerieII_III.Models
{
    public class PizzaModel
    {
      
        public string Id { get; set; }

        public string NombrePizza { get; set; }

        public string Descripcion { get; set; }

        public string[] Ingredientes { get; set; }

        public string Masa { get; set; }
        public string Tamano { get; set; }
        public int Porciones { get; set; }
        public bool Queso { get; set; }
    }
}
