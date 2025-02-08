namespace PMatches.Frontend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string EquipNameHome { get; set; }
        public string EquipNameVisitor { get; set; }
        public bool WinHome { get; set; }
        public int PointsFromVisitor { get; set; } 
        public int PointsFromHome { get; set; } 
        public decimal Prize { get; set; } 
    }
}
