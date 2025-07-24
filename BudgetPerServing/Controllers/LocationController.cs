using BudgetPerServing.Data.Models;
using BudgetPerServing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Location>> PostFoodItem(Location location)
        {
            await locationService.CreateLocationAsync(location);

            return CreatedAtAction("", new { id = location.Id });
        }
    }
}
