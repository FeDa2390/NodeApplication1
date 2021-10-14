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
        // public DbSet<Vacancy> Vacancies { get; set; }
        // public DbSet<Company> Companies { get; set; }
        // public DbSet<CandidateVacancy> CandidatesVacancy { get; set; }
    }
}