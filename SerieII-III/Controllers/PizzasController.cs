using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SerieII_III.Models;
using SerieII_III.Services;

namespace SerieII_III.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaService _pizzaService;

        public PizzasController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<List<PizzaModel>> Get() =>
         _pizzaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPizza")]
        public ActionResult<PizzaModel> Get(string id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public ActionResult<PizzaModel> Create(PizzaModel Pizza)
        {
            _pizzaService.Create(Pizza);

            return CreatedAtRoute("GetPizza", new { id = Pizza.Id.ToString() }, Pizza);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PizzaModel NewPizza)
        {
            var pizza = _pizzaService.Get(id);
            if (pizza == null)
            {
                return NotFound();
            }
            NewPizza.Id = id;
            _pizzaService.Update(id, NewPizza);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza == null)
            {
                return NotFound();
            }

            _pizzaService.Remove(pizza.Id);

            return Ok();
        }
    }
}