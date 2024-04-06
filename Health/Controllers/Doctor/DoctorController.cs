namespace Health.Controllers.Doctor
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Health.Models.Doctor;
    using Health.Data.DbContext;

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HealthDbContext Context;

        public DoctorController(HealthDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await Context.Doctors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var Doctor = await Context.Doctors.FindAsync(id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Doctor;
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor Doctor)
        {
            Context.Doctors.Add(Doctor);
            await Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoctor), new { id = Doctor.Id }, Doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor Doctor)
        {
            if (id != Doctor.Id)
            {
                return BadRequest();
            }

            Context.Entry(Doctor).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var Doctor = await Context.Doctors.FindAsync(id);
            if (Doctor == null)
            {
                return NotFound();
            }

            Context.Doctors.Remove(Doctor);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return Context.Doctors.Any(e => e.Id == id);
        }
    }
}
