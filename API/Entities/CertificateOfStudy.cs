using System;

namespace API.Entities
{
    public class CertificateOfStudy
    {
        public int Id { get; set; }
        public Candidate CertCandidate { get; set; }
        public DateTime CertDate { get; set; }
        public string Certificate { get; set; }
        public string Description { get; set; }
        public string SchoolUniversity { get; set; }
    }
}