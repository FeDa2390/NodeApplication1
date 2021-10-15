namespace API.Entities
{
    public class Dossier
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Document { get; set; }
        public Candidate DossierCandidate { get; set; }
    }
}