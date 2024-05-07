using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly DrinkDal _drinkDAL;

        public DrinksController(DrinkDal drinkDAL)
        {
            _drinkDAL = drinkDAL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Drink>> GetDrinks([FromQuery] string sortByCost)
        {
            List<Drink> drinks = _drinkDAL.GetDrinks(sortByCost);
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public ActionResult<Drink> GetDrinkById(int id, [FromServices] DrinkDal drinkDAL)
        {
            var drink = drinkDAL.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost]
        public ActionResult<Drink> AddDrink(Drink newDrink, [FromServices] DrinkDal drinkDAL)
        {
            var drink = drinkDAL.AddDrink(newDrink);
            return CreatedAtAction(nameof(GetDrinkById), new { id = drink.ID }, drink);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDrink(int id, Drink drink, [FromServices] DrinkDal drinkDAL)
        {
            if (id != drink.ID)
            {
                return BadRequest();
            }

            drinkDAL.UpdateDrink(drink);
            return NoContent();
        }
    }
}
