namespace Health.Data.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Health.Models.Doctor;
    using Health.Models.Client;
    using Health.Models.Procedure;
    using Health.Models.PaymentMethod;

    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
