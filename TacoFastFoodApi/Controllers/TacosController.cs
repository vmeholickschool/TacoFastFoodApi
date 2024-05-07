using Microsoft.AspNetCore.Mvc;

using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        private readonly TacoDal _tacoDal;

        public TacosController(TacoDal tacoDal)
        {
            _tacoDal = tacoDal ;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Taco>> GetTacos([FromQuery] bool? softShell)
        {
            var tacos = _tacoDal.GetTacos(softShell);
            return Ok(tacos);
        }

        [HttpGet("{id}")]
        public ActionResult<Taco> GetTacoById(int id)
        {
            var taco = _tacoDal.GetTacosById(id);
            if (taco == null)
            {
                return NotFound();
            }
            return Ok(taco);
        }
        [HttpPost]
        public ActionResult<Taco> AddTaco(Taco newTaco, TacoDal tacoDal)
        {
            var taco = tacoDal.AddTaco(newTaco);
            return CreatedAtAction(nameof(GetTacoById), new { id = taco.ID }, taco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaco(int id, [FromServices] TacoDal tacoDal)
        {
            var deleted = tacoDal.DeleteTaco(id);
            if (deleted)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
