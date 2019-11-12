using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Serie23.Models
{
    public class PizzaDatabaseSettings : IPizzasDatabaseSettings
    {
        public string PizzasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPizzasDatabaseSettings
    {
        string PizzasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
