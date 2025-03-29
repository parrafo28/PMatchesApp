using Microsoft.EntityFrameworkCore;
using PMatches.Domain.DTOs;
using PMatches.Domain.Entities;
using PMatches.Persistence;
using PMatches.Presentation.Responses;

namespace PMatches.Infrastructure.Repositories
{
    public class TeamRepository
    {
        private readonly DataContext _context;
        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Team> GetEntityById(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task<Response<TeamDto>> GetById(int id)
        {
            var entity = await GetEntityById(id);

            if (entity == null)
            {
                return new Response<TeamDto> { Success = false, Message = "Not Found" };
            }

            var response = new TeamDto
            { 
                Name = entity.Name, 
                Id = entity.Id
            };

            return new Response<TeamDto> { Success = true, Data = response };

        }

        public async Task<Response<List<TeamDto>>> GetAll(string filter = "")
        {
            var list = _context.Teams.Where(P => P.Id > 0);

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower()));
            }

            var entities = await list.ToListAsync();
            List<TeamDto> response = new List<TeamDto>();

            foreach (var entity in entities)
            {
                response.Add(new TeamDto { Id = entity.Id, Name = entity.Name });
            }
            return new Response<List<TeamDto>> { Success = true, Data = response };

        }

        public async Task<Response<TeamDto>> Create(TeamDto dto)
        {
            var entity = new Team { Name = dto.Name };
            _context.Teams.Add(entity);
            await _context.SaveChangesAsync();

            return new Response<TeamDto> { Success = true, Message = "Created successfully!" };
        }

        public async Task<Response<TeamDto>> Update(TeamDto dto)
        { 
            var entity = await GetEntityById(dto.Id);

            if (entity == null)
            {
                return new Response<TeamDto> { Success = false, Message = "Not Found" };
            }

            entity.Name = dto.Name;

            _context.Teams.Update(entity);
            await _context.SaveChangesAsync();

            return new Response<TeamDto> { Success = true, Message = "Updated successfully!" };

        }
    }
}
