using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PMatches.Frontend.Models
{
    public class TeamModel
    {
          public int Id { get; set; }

        public string Name { get; set; }
     
        public string Initials { get; set; }
         
        [DataType(DataType.ImageUrl)]
        public string PictureUrl { get; set; }

        public int? MatchesPlayed { get; set; }

        public int? FavorPoints { get; set; }

        public int? AgainstPoints { get; set; }

        public int? MatchesWon { get; set; }

        public int? MatchesLost { get; set; }

        public int? CumulativePoints { get; set; }

        public int? MatchesTied { get; set; }

        public int? Position { get; set; }
         
    }
}
