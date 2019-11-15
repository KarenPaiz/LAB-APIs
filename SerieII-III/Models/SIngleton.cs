using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerieII_III.Models
{
    public class SIngleton
    {
            private static SIngleton _instance = null;
            public static SIngleton Instance
            {
                get
                {
                    if (_instance == null) _instance = new SIngleton();
                    {
                        return _instance;
                    }
                }
            }
            public List<PizzaModel> ListaPizzas = new List<PizzaModel>() ;
    }
}
