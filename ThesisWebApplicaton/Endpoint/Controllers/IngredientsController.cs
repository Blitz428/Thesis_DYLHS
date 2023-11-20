using Microsoft.AspNetCore.Mvc;
using Thesis.Models;
using ThesisApi.Services;

namespace ThesisApi.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService) =>
            _ingredientsService = ingredientsService;

        [HttpGet]
        public async Task<List<Ingredient>> Get() =>
            await _ingredientsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Ingredient>> Get(string id)
        {
            var ingredient = await _ingredientsService.GetAsync(id);

            if (ingredient is null)
            {
                return NotFound();
            }

            return ingredient;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ingredient newIngredient)
        {
            await _ingredientsService.CreateAsync(newIngredient);

            return CreatedAtAction(nameof(Get), new { id = newIngredient._Id }, newIngredient);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Ingredient updatedingredient)
        {
            var ingredient = await _ingredientsService.GetAsync(id);

            if (ingredient is null)
            {
                return NotFound();
            }

            updatedingredient._Id = ingredient._Id;

            await _ingredientsService.UpdateAsync(id, updatedingredient);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var ingredient = await _ingredientsService.GetAsync(id);

            if (ingredient is null)
            {
                return NotFound();
            }

            await _ingredientsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
