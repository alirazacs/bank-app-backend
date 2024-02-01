using Microsoft.EntityFrameworkCore;

namespace BankAppBackend.Models
{
    public class DatabaseContext :DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Teller> Tellers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Applicant>(applicant =>
            {
                applicant.HasIndex(customer => customer.CNIC).IsUnique(true);
            });

            modelBuilder.Entity<Teller>(tellerEntity =>
            {
                tellerEntity.HasMany(teller => teller.Applicants)
                .WithOne(applicant => applicant.Teller)
                .HasForeignKey(applicant => applicant.TellerId);
            });

            modelBuilder.Entity<Applicant>(applicantEntity =>
            {
                applicantEntity.HasOne(applicant => applicant.Customer)
                .WithOne(customer => customer.Applicant)
                .HasForeignKey<Customer>(customer => customer.ApplicantId);
            });

            modelBuilder.Entity<Customer>(customerEntity =>
            {
                customerEntity.HasMany(customer => customer.Accounts)
                .WithOne(account => account.Customer)
                .HasForeignKey(account => account.CustomerId);
            });
        }
    }
}
