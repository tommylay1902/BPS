
using BudgetPerServing.Clients;
using BudgetPerServing.Data.Clients;
using BudgetPerServing.Services;
using Microsoft.AspNetCore.Mvc;

using FoodItem = BudgetPerServing.Data.Models.FoodItem;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController( IFdcClient fdcClient, ILogger<FoodItemController> logger, IFoodItemService fiService) : ControllerBase
    {
     
        // GET: api/FoodItem
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
        
            return Ok(await fiService.GetFoodItemsAsync());
        }*/

        [HttpGet("search")]
        public async Task<ActionResult<FoodSearchApiResponse>> SearchFoodsAsync()
        {
            var query = HttpContext.Request.Query["query"].ToString();
            var response = await fdcClient.SearchFoodsAsync(query);
            return Ok(response);
        }
        
        // GET: api/FoodItem/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodGetByIdApiResponse>> GetFoodItem(int id)
        {
            var response = await fdcClient.GetFoodByIdAsync(id);

            return Ok(response);
        }
        
        // POST: api/FoodItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
            await fiService.CreateFoodItemAsync(foodItem);

            return CreatedAtAction("GetFoodItem", new { id = foodItem.Id });
        }



        // GET: api/FoodItem/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(Guid id)
        {
            var foodItem = await context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return foodItem;
        }

        // PUT: api/FoodItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodItem(Guid id, FoodItem foodItem)
        {
            if (id != foodItem.Id)
            {
                return BadRequest();
            }

            context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/FoodItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(Guid id)
        {
            var foodItem = await context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            context.FoodItems.Remove(foodItem);
            await context.SaveChangesAsync();

            return NoContent();
        }*/

        /*private bool FoodItemExists(Guid id)
        {
            return context.FoodItems.Any(e => e.Id == id);
        }*/
    }
}

