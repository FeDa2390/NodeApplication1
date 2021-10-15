namespace API.DTOs
{
    public class CandidateUpdateDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
    }
}