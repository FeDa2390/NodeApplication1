using System;

namespace API.DTOs
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string NameCandidate { get; set; }
        public string SurnameCandidate { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
    }
}