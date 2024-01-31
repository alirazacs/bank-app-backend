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
            modelBuilder.Entity<Teller>()
                .HasMany(teller => teller.applicants)
                .WithOne(applicant => applicant.Teller)
                .HasForeignKey(teller => teller.TellerId);
        }
    }
}
