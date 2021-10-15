using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Certificate { get; set; }
        public string Experience { get; set; }
        public int Vacancies { get; set; }
        public int ContractPeriod { get; set; }
        public int WorkingHours { get; set; }
        public double Salary { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}