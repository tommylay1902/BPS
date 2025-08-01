
using BudgetPerServing.Data.Dto;
using BudgetPerServing.Data.Models;
using BudgetPerServing.Exceptions;
using BudgetPerServing.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreService storeService, ILogger<StoreController> logger, IWebHostEnvironment env) : ControllerBase
    {
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Store>> GetStoreById(Guid id)
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
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Store>> PostStore([FromBody] CreateStoreRequest store)
        {
            try
            {
                var createdStoreId = await storeService.CreateStoreAsync(store);
                logger.LogInformation(createdStoreId + "");
                return CreatedAtAction("GetStoreById", new { id = createdStoreId }, new Store{Name=store.Name, LocationId = store.LocationId, Id =  createdStoreId});
            }
            catch (ResourceConflictException ex)
            {
                return Problem(
                    detail: ex.Message,
                    title:"Resource Conflict",
                    statusCode: StatusCodes.Status409Conflict,
                    instance: HttpContext.TraceIdentifier
                );
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                }
                return Problem(
                    detail: "An unexpected error occurred while processing your request.",
                    title: "Internal Server Error",
                    statusCode: StatusCodes.Status500InternalServerError,
                    instance: HttpContext.TraceIdentifier
                );
            }
        }
        
        [HttpPost("with-location")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Store>> PostStoreWithLocation([FromBody] CreateStoreWithLocationRequest request)
        {
            try
            {
                var (createdStoreId, createdLocationId) = await storeService.CreateStoreWithLocation(request);
                return CreatedAtAction("GetStoreById", new { id = createdStoreId }, new Store{Name=request.Name, LocationId = createdLocationId, Id =  createdStoreId});
            }
            catch (ResourceConflictException ex)
            {
                return Problem(
                    detail: ex.Message,
                    title:"Resource Conflict",
                    statusCode: StatusCodes.Status409Conflict,
                    instance: HttpContext.TraceIdentifier
                );
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                {
                    logger.LogError(ex.Message);
                }
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
        public async Task<ActionResult<IList<Store>>> GetStore()
        {
            try
            {
                var stores = await storeService.GetAllStoresWithLocationEagerLoadAsync();

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

        [HttpPatch("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateStore(Guid id, [FromBody] StoreUpdateRequest request)
        {
            try
            {
                await storeService.UpdateStoreAsync(id, request);
                return NoContent();
            }
            catch (ResourceConflictException ex)
            {
                logger.LogWarning("hit the resource conflict");
                return Problem(
                    detail: ex.Message,
                    title:"Resource Conflict",
                    statusCode: StatusCodes.Status409Conflict,
                    instance: HttpContext.TraceIdentifier
                );
            }
            catch (KeyNotFoundException ex)
            {
                return Problem(
                    detail: $"Store with ID {id} was not found.",
                    title: "Store not found",
                    statusCode: StatusCodes.Status404NotFound,
                    instance: HttpContext.TraceIdentifier
                );
            }
            catch (NoUpdateException ex)
            {
                return Problem(
                    detail: "No updates found on resource.",
                    title: "No Updates found",
                    statusCode: StatusCodes.Status400BadRequest,
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

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStore(Guid id)
        {
            try
            {
                await storeService.DeleteStoreAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return Problem(
                    detail: ex.Message,
                    title: "Store not found. Can't Delete",
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

  

    }
}
