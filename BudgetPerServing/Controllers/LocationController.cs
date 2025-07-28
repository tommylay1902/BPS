using BudgetPerServing.Data.Models;
using BudgetPerServing.Services;

using Microsoft.AspNetCore.Mvc;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService, ILogger<LocationController> logger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Location>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()
        {
            try
            {
                var locations = await  locationService.GetAllLocationsAsync();
                return Ok(locations);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "An unexpected error occurred while processing your request.",
                    title: "Internal Server Error",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: HttpContext.TraceIdentifier
                );
            }
            
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Location))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<Location>> GetLocationById(Guid id)
        {
            try
            {
                var location = await locationService.GetLocationByIdAsync(id);
                if (location != null) return Ok(location);
                logger.LogError($"Location with id: {id} was not found");
                return Problem(
                    detail: $"Location with ID {id} was not found.",
                    title: "Location not found",
                    statusCode: StatusCodes.Status404NotFound,
                    instance: HttpContext.TraceIdentifier
                );

            }
            catch (Exception ex)
            {
                return Problem(
                    detail: "An unexpected error occurred while processing your request.",
                    title: "Internal Server Error",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: HttpContext.TraceIdentifier
                );
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(Location), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<Location>> PostLocation([FromBody] Location location)
        {
            try
            {
                await locationService.CreateLocationAsync(location);

                return CreatedAtAction("GetLocationById", new { id = location.Id }, location);
            }
            catch (Exception e)
            {
                return Problem(
                    detail: "An unexpected error occurred while processing your request.",
                    title: "Internal Server Error",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: HttpContext.TraceIdentifier
                );
            }
        }
    }
}
