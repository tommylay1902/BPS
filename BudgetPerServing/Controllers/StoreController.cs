
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;
using BudgetPerServing.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService storeService, ILogger<StoreController> logger) : ControllerBase
    {

        /*[HttpGet("{id:guid}")]
        public async Task<Store> GetStoreByIdAsync(Guid id)
        {
            return Ok();
        }*/
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Store>> PostStoreAsync([FromBody] CreateStoreRequest store)
        {
            try
            {
                await storeService.CreateStoreAsync(store);
                return Ok(store);
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Store>>> GetStoreAsync()
        {
            try
            {
                var stores = await storeService.GetAllStoresAsync();

                return Ok(stores);
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

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Store>> GetStoreByIdAsync(Guid id)
        {
            try
            {
                var store = await storeService.GetStoreByIdAsync(id);

                if (store == null)
                {
                    return NotFound();
                }

                return Ok(store);
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

    }
}
