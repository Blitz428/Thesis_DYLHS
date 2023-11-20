using Microsoft.AspNetCore.Mvc;
using Thesis.Models;
using ThesisApi.Services;
using ThesisWebApplicaton;

namespace ThesisApi.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly DrinksService _drinksService;

        public DrinksController(DrinksService drinksService) =>
            _drinksService = drinksService;

        [HttpGet]
        public async Task<List<Drink>> Get() =>
            await _drinksService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Drink>> Get(string id)
        {
            var drink = await _drinksService.GetAsync(id);

            if (drink is null)
            {
                return NotFound();
            }

            return drink;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Drink newDrink)
        {
            await _drinksService.CreateAsync(newDrink);

            return CreatedAtAction(nameof(Get), new { id = newDrink._Id }, newDrink);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Drink updatedDrink)
        {
            var drink = await _drinksService.GetAsync(id);

            if (drink is null)
            {
                return NotFound();
            }

            updatedDrink._Id = drink._Id;

            await _drinksService.UpdateAsync(id, updatedDrink);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var drink = await _drinksService.GetAsync(id);

            if (drink is null)
            {
                return NotFound();
            }

            await _drinksService.RemoveAsync(id);

            return NoContent();
        }
    }
}