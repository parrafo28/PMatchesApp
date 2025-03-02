using PMatches.Domain.Entities;
using PMatches.Frontend.Data.Entities;
using PMatches.Frontend.Models;

namespace PMatches.Frontend.Utils
{
    public static class EntityViewModelConverter
    {
        public static MatchViewModel MatchEntityToViewModel(Match? entityM)
        {
            var modelE = new MatchViewModel();
            modelE.WinHome = entityM.WinHome;
            modelE.PointsFromVisitor = entityM.PointsFromVisitor;
            modelE.EquipNameVisitor = entityM.EquipNameVisitor;
            modelE.PointsFromHome = entityM.PointsFromHome;
            modelE.EquipNameHome = entityM.EquipNameHome;
            modelE.Prize = entityM.Prize;
            modelE.StatusId = entityM.StatusId;
            return modelE;
        }
    }
}
