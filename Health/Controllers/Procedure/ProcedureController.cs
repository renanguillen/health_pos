namespace Health.Controllers.Procedure
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Health.Models.Procedure;
    using Health.Data.DbContext;

    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly HealthDbContext Context;

        public ProcedureController(HealthDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedure>>> GetProcedures()
        {
            return await Context.Procedures.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Procedure>> GetProcedure(int id)
        {
            var Procedure = await Context.Procedures.FindAsync(id);

            if (Procedure == null)
            {
                return NotFound();
            }

            return Procedure;
        }

        [HttpPost]
        public async Task<ActionResult<Procedure>> PostProcedure(Procedure Procedure)
        {
            Context.Procedures.Add(Procedure);
            await Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcedure), new { id = Procedure.Id }, Procedure);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedure(int id, Procedure Procedure)
        {
            if (id != Procedure.Id)
            {
                return BadRequest();
            }

            Context.Entry(Procedure).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedure(int id)
        {
            var Procedure = await Context.Procedures.FindAsync(id);
            if (Procedure == null)
            {
                return NotFound();
            }

            Context.Procedures.Remove(Procedure);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcedureExists(int id)
        {
            return Context.Procedures.Any(e => e.Id == id);
        }
    }
}
