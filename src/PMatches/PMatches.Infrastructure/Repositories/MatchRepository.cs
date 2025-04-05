using Microsoft.EntityFrameworkCore;
using PMatches.Domain.DTOs;
using PMatches.Domain.Entities;
using PMatches.Infrastructure.Core;
using PMatches.Persistence;
using PMatches.Presentation.Responses;

namespace PMatches.Infrastructure.Repositories
{
    public class MatchRepository : BaseRepository<Match>, IMatchRepository
    {
        public MatchRepository(DataContext context) : base(context)
        {
        }

        public async Task<Response<MatchDto>> GetById(int id)
        {
            var entity = await GetEntityById(id);

            if (entity == null)
            {
                return new Response<MatchDto> { Success = false, Message = "Not Found" };
            }

            var response = new MatchDto
            {
                EquipNameVisitor = entity.EquipNameVisitor,
                PointsFromHome = entity.PointsFromHome,
                PointsFromVisitor = entity.PointsFromVisitor,
                Prize = entity.Prize,
                StatusId = entity.StatusId,
                WinHome = entity.WinHome,
                EquipNameHome = entity.EquipNameHome,
                Id = entity.Id
            };

            return new Response<MatchDto> { Success = true, Data = response };
        }

        public async Task<Response<List<MatchDto>>> GetAll(string filter = "")
        {
            var list = Context.Matches.Where(P => P.Id > 0);

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.EquipNameHome.ToLower().Contains(filter.ToLower())
                || d.EquipNameVisitor.ToLower().Contains(filter.ToLower()));
            }

            var entities = await list.ToListAsync();
            List<MatchDto> response = new List<MatchDto>();

            foreach (var entity in entities)
            {
                response.Add(new MatchDto
                {
                    Id = entity.Id,
                    EquipNameHome = entity.EquipNameHome,
                    EquipNameVisitor = entity.EquipNameVisitor,
                    PointsFromHome = entity.PointsFromHome,
                    PointsFromVisitor = entity.PointsFromVisitor,
                    Prize = entity.Prize,
                    StatusId = entity.StatusId,
                    WinHome = entity.WinHome
                });
            }
            return new Response<List<MatchDto>> { Success = true, Data = response };

        }

        public async Task<Response<MatchDto>> Create(MatchDto dto)
        {
            var entity = new Match
            {
                EquipNameHome = dto.EquipNameHome,
                EquipNameVisitor = dto.EquipNameVisitor,
                PointsFromHome = dto.PointsFromHome,
                PointsFromVisitor = dto.PointsFromVisitor,
                Prize = dto.Prize,
                StatusId = dto.StatusId,
                WinHome = dto.WinHome
            };

            var unit = await Add(entity);
            if (unit != 0)
                return new Response<MatchDto> { Success = true, Message = "Updated successfully!" };
            else
                return new Response<MatchDto> { Success = false, Message = "Error Updating teh resource" };
        }

        public async Task<Response<MatchDto>> Update(MatchDto dto)
        {
            var entity = await GetEntityById(dto.Id);

            if (entity == null)
            {
                return new Response<MatchDto> { Success = false, Message = "Not Found" };
            }

            entity.Id = dto.Id;
            entity.EquipNameHome = dto.EquipNameHome;
            entity.EquipNameVisitor = dto.EquipNameVisitor;
            entity.PointsFromHome = dto.PointsFromHome;
            entity.PointsFromVisitor = dto.PointsFromVisitor;
            entity.Prize = dto.Prize;
            entity.StatusId = dto.StatusId;
            entity.WinHome = dto.WinHome;

            var unit = await Update(entity);
            if (unit)
                return new Response<MatchDto> { Success = true, Message = "Updated successfully!" };
            else
                return new Response<MatchDto> { Success = false, Message = "Error Updating the resource" };


        }
    }
}
