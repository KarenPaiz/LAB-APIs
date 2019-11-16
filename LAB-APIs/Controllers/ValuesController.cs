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
        public string Post([FromBody]Dictionary<string,object>objeto, string value)
        {

            var buffer = value.PadRight(64, ' ')
                .ToCharArray()
                .Select(x => Convert.ToByte(x))
                .ToArray();
            var hander = new JwtSecurityTokenHandler();
            var claims = objeto.Select(x => new Claim(x.Key, x.Value.ToString()));
            var description = new SecurityTokenDescriptor {
                Issuer = "todos",
                Audience = "audiencia",
                Expires = DateTime.UtcNow.AddSeconds(10),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(buffer),SecurityAlgorithms.HmacSha256)
            };
            var token = hander.CreateToken(description);
            
            var tokenstring = hander.WriteToken(token);
            return tokenstring;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) { 
        
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
