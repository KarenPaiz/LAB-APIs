using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SerieII_III.Models;
//using SerieII_III.Services;

namespace SerieII_III.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<PizzaModel>> Get() =>
         SIngleton.Instance.ListaPizzas.FindAll(PizzaModel => true);

        [HttpGet("{id}")]
        public ActionResult<PizzaModel> Get(string id)
        {
            var pizza = SIngleton.Instance.ListaPizzas.Find(PizzaModel => PizzaModel.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public ActionResult<PizzaModel> Create(PizzaModel Pizza)
        {
            SIngleton.Instance.ListaPizzas.Add(Pizza);

            return Ok(Pizza);
        }

        [HttpPut("{id:}")]
        public IActionResult Update(string id, PizzaModel NewPizza)
        {
            var pizza = SIngleton.Instance.ListaPizzas.Find(PizzaModel => PizzaModel.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }
            NewPizza.Id = id;
            SIngleton.Instance.ListaPizzas.Remove(pizza);
            SIngleton.Instance.ListaPizzas.Add(NewPizza);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var pizza = SIngleton.Instance.ListaPizzas.Find(PizzaModel => PizzaModel.Id == id);

            if (pizza == null)
            {
                return NotFound();
            }

            SIngleton.Instance.ListaPizzas.Remove(pizza);

            return Ok();
        }
    }
}