using BudgetPerServing.Data.Models;
using BudgetPerServing.Services;

using Microsoft.AspNetCore.Mvc;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Location>>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Location>> GetLocationById(Guid id)
        {
            var location = await locationService.GetLocationByIdAsync(id);
            if (location == null) return NotFound();

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation([FromBody] Location location)
        {
            await locationService.CreateLocationAsync(location);

            return CreatedAtAction("GetLocationById", new { id = location.Id }, location);
    }
        
        
    }
}
