namespace PMatches.Domain.Entities
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MatchModel> Matches { get; set; }
    }
}
