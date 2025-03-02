using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PMatches.Api.Dtos
{
    public class MatchDto
    { 
        public int Id { get; set; }

        [DisplayName("Home Club")]
        [Required(ErrorMessage = "El campo de home es Reequerido")]
        [StringLength(50, ErrorMessage = "La longitud maxima es 50")]
        [MinLength(3)]
        public string? EquipNameHome { get; set; }

        [DisplayName("Visitante")]
        [Required(ErrorMessage = "El campo de visitante es Reequerido")]
        [StringLength(50, ErrorMessage = "La longitud maxima es 50")]
        public string? EquipNameVisitor { get; set; }
        public bool WinHome { get; set; }
        public int PointsFromVisitor { get; set; }
        public int PointsFromHome { get; set; }
        public decimal Prize { get; set; }
        public int StatusId { get; set; }
        public SelectList? StatusList { get; set; }
         
    }
}
