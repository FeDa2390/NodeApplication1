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
        public string Gender { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<CertificateOfStudy> Certificates { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}