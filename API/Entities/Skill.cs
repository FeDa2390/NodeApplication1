using System.Collections.Generic;

namespace API.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Description { get; set; }
        public string SkillType { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
    }
}