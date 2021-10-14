namespace API.Helpers
{
    public class CandidateParams
    {
        public string CurrentUserName { get; set; }
        public string Qualification { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 150;
        public string City { get; set; }
        public string OrderBy { get; set; } = "name";
    }
}