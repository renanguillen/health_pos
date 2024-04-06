namespace Health.Controllers.PaymentMethod
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Health.Models.PaymentMethod;
    using Health.Data.DbContext;

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly HealthDbContext Context;

        public PaymentMethodController(HealthDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            return await Context.PaymentMethods.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var PaymentMethod = await Context.PaymentMethods.FindAsync(id);

            if (PaymentMethod == null)
            {
                return NotFound();
            }

            return PaymentMethod;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethod PaymentMethod)
        {
            Context.PaymentMethods.Add(PaymentMethod);
            await Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentMethod), new { id = PaymentMethod.Id }, PaymentMethod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentMethod(int id, PaymentMethod PaymentMethod)
        {
            if (id != PaymentMethod.Id)
            {
                return BadRequest();
            }

            Context.Entry(PaymentMethod).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(id))
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
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var PaymentMethod = await Context.PaymentMethods.FindAsync(id);
            if (PaymentMethod == null)
            {
                return NotFound();
            }

            Context.PaymentMethods.Remove(PaymentMethod);
            await Context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentMethodExists(int id)
        {
            return Context.PaymentMethods.Any(e => e.Id == id);
        }
    }
}
