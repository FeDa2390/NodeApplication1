using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }        
        public DbSet<CertificateOfStudy> CertificatesOfStudy { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContractPeriod> ContractsPeriod { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Candidate>()
                .HasMany(v => v.Vacancies)
                .WithMany(c => c.Candidates)
                .UsingEntity(cv => cv.ToTable("CandidateVacancy"));

            builder.Entity<Candidate>()
                .HasMany(s => s.Skills)
                .WithMany(c => c.Candidates)
                .UsingEntity(cs => cs.ToTable("CandidateSkill"));
        }
    }
}