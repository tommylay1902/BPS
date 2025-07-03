using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetPerServing.Data;
using BudgetPerServing.Data.Models;

namespace BudgetPerServing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServingLogController(ApplicationDbContext context) : ControllerBase
    {
        // GET: api/ServingLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServingLog>>> GetServingLogs()
        {
            return await context.ServingLogs.ToListAsync();
        }

        // GET: api/ServingLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServingLog>> GetServingLog(Guid id)
        {
            var servingLog = await context.ServingLogs.FindAsync(id);

            if (servingLog == null)
            {
                return NotFound();
            }

            return servingLog;
        }

        // PUT: api/ServingLog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServingLog(Guid id, ServingLog servingLog)
        {
            if (id != servingLog.Id)
            {
                return BadRequest();
            }

            context.Entry(servingLog).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServingLogExists(id))
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

        // POST: api/ServingLog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServingLog>> PostServingLog(ServingLog servingLog)
        {
            context.ServingLogs.Add(servingLog);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetServingLog", new { id = servingLog.Id }, servingLog);
        }

        // DELETE: api/ServingLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServingLog(Guid id)
        {
            var servingLog = await context.ServingLogs.FindAsync(id);
            if (servingLog == null)
            {
                return NotFound();
            }

            context.ServingLogs.Remove(servingLog);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServingLogExists(Guid id)
        {
            return context.ServingLogs.Any(e => e.Id == id);
        }
    }
}
