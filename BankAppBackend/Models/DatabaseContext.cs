using Microsoft.EntityFrameworkCore;

namespace BankAppBackend.Models
{
    public class DatabaseContext :DbContext
    {
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<Teller> tellers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teller>(tellerEntity =>
            {
                tellerEntity.HasMany(teller => teller.Applicants)
                .WithOne(applicant => applicant.Teller)
                .HasForeignKey(applicant => applicant.TellerId);
            });

            modelBuilder.Entity<Applicant>(applicantEntity =>
            {
                applicantEntity.HasOne(applicant => applicant.customer)
                .WithOne(customer => customer.Applicant)
                .HasForeignKey<Customer>(customer => customer.ApplicantId);
            });
        }
    }
}
