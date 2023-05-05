using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
            PizzaService.GetAll();

        [HttpGet("{id:int}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPost]
        public IActionResult Add(Pizza pizza)
        {

            /*#region My-Method
            try
            {
                *//*throw new Exception("bad request by me");*//*
                PizzaService.Add(pizza);
                return Ok(new { JacksPizza = pizza });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            #endregion*/

            #region Tutorial
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
            #endregion

        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            /*#region My-Method
            try
            {
                PizzaService.Update(pizza);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            #endregion*/


            #region Tutorial
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
            #endregion
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            /*#region My-Method
            try
            {
                PizzaService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            #endregion*/
            

            #region Tutorial
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
            #endregion

        }
    }

}
