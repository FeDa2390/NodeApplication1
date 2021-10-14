using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API.Entities
{
    public class CandidateVacancy : IdentityUser
    {
        public Candidate Candidate { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}