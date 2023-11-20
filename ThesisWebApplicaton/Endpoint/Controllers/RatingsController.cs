using Microsoft.AspNetCore.Mvc;
using Thesis.Models;
using ThesisApi.Services;

namespace ThesisApi.Endpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly RatingsService _ratingsService;

        public RatingsController(RatingsService ratingsService) =>
            _ratingsService = ratingsService;

        [HttpGet]
        public async Task<List<Rating>> Get() =>
            await _ratingsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Rating>> Get(string id)
        {
            var rating = await _ratingsService.GetAsync(id);

            if (rating is null)
            {
                return NotFound();
            }

            return rating;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Rating newRating)
        {
            await _ratingsService.CreateAsync(newRating);

            return CreatedAtAction(nameof(Get), new { id = newRating._Id }, newRating);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Rating updatedRating)
        {
            var rating = await _ratingsService.GetAsync(id);

            if (rating is null)
            {
                return NotFound();
            }

            updatedRating._Id = rating._Id;

            await _ratingsService.UpdateAsync(id, updatedRating);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rating = await _ratingsService.GetAsync(id);

            if (rating is null)
            {
                return NotFound();
            }

            await _ratingsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
