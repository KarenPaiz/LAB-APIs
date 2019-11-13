using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Logging;

namespace LAB_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(string value, Estudiante elemento)
        {
            var valueAux = value;
            if (valueAux.Length < 32)
            {
                for (int i = 32; i > value.Length; i--)
                {
                    valueAux += ".";
                }
            }           
            if (valueAux.Length > 32)
            {
                valueAux = valueAux.Substring(0, 32);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        class Singleton
        {
            private static Singleton claseSingleton;
            public string token;
            public static Singleton Datos
            {
                get
                {
                    if (claseSingleton == null)
                    {
                        claseSingleton = new Singleton();
                    }
                    return claseSingleton;
                }
            }            
        }
    }
}
