
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
        public async Task<ActionResult<Store>> PostStoreAsync([FromBody] CreateStoreRequest store)
        {
            logger.LogInformation(store.LocationId.ToString());
            await storeService.CreateStoreAsync(store);

            return Ok(store);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Store>>> GetStoreAsync([FromQuery] int storeId)
        {
            var stores = await storeService.GetAllStoresAsync();

            return Ok(stores);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Store>> GetStoreByIdAsync(Guid id)
        {
            var store = await storeService.GetStoreByIdAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

    }
}
