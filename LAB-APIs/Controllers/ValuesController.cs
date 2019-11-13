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
        public ActionResult<string> Get()
        {
            return Singleton.Datos.token;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("{value}")]
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

            var password = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(valueAux));
            var Credenciales = new SigningCredentials(password, SecurityAlgorithms.HmacSha256);
            var peticiones = new Claim[4];//TAMANIO DE PROPIEDADES DE MI CLASE KAREN
            peticiones[0] = new Claim("carnet", elemento.carnet.ToString());
            peticiones[1] = new Claim("edad", elemento.edad.ToString());
            peticiones[2] = new Claim("carrera", elemento.carrera);
            peticiones[3] = new Claim("nombre", elemento.nombre);
            var encabezado = new JwtHeader(Credenciales);
            var cuerpo = new JwtPayload(peticiones);
            var token = new JwtSecurityToken(encabezado, cuerpo);
            //IdentityModelEventSource.showII = true;
            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            Singleton.Datos.token = tokenstring;
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
