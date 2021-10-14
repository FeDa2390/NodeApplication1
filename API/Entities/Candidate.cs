using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string NameCandidate { get; set; }
        public string SurnameCandidate { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public ICollection<CandidateVacancy> CandidateVacancies { get; set; }
    }
}