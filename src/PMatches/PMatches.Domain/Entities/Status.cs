using PMatches.Domain.Core;

namespace PMatches.Domain.Entities
{
    public class Status : BaseEntity
    {
       
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
