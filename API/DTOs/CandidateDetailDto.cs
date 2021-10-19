using System.Collections.Generic;

namespace API.DTOs
{
    public class CandidateDetailDto
    {
        public string Username { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string NameCandidate { get; set; }
        public string SurnameCandidate { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }
    }
}