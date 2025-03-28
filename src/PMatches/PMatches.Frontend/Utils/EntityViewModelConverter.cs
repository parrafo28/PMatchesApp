using PMatches.Domain.Entities;
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

        public static Match MatchViewModelToEntity(MatchViewModel? vm)
        {
            var entity = new Match();
            entity.WinHome = vm.WinHome;
            entity.PointsFromVisitor = vm.PointsFromVisitor;
            entity.EquipNameVisitor = vm.EquipNameVisitor;
            entity.PointsFromHome = vm.PointsFromHome;
            entity.EquipNameHome = vm.EquipNameHome;
            entity.Prize = vm.Prize;
            entity.StatusId = vm.StatusId;
            return entity;
        }
    }
}
