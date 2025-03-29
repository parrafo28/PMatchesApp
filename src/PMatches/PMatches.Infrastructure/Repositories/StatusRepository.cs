using Microsoft.EntityFrameworkCore;
using PMatches.Domain.DTOs;
using PMatches.Domain.Entities;
using PMatches.Infrastructure.Core;
using PMatches.Persistence;
using PMatches.Presentation.Responses;

namespace PMatches.Infrastructure.Repositories
{
    public class StatusRepository : BaseRepository<Status>
    {
        public StatusRepository(DataContext context) : base(context)
        {
        }

        public async Task<Response<StatusDto>> GetById(int id)
        {
            var entity = await GetEntityById(id);

            if (entity == null)
            {
                return new Response<StatusDto> { Success = false, Message = "Not Found" };
            }

            var response = new StatusDto
            {
                Name = entity.Name,
                Id = entity.Id
            };

            return new Response<StatusDto> { Success = true, Data = response };

        }

        public async Task<Response<List<StatusDto>>> GetAll(string filter = "")
        {
            var list = Context.Status.Include(p => p.Matches).Where(P => P.Id > 0);

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower()));
            }

            var entities = await list.ToListAsync();
            List<StatusDto> response = new List<StatusDto>();

            foreach (var entity in entities)
            {
                response.Add(new StatusDto { Id = entity.Id, Name = entity.Name });
            }
            return new Response<List<StatusDto>> { Success = true, Data = response };

        }

        public async Task<Response<StatusDto>> Create(StatusDto dto)
        {
            var entity = new Status { Name = dto.Name };
            var unit = await Add(entity);
            if (unit != 0)
                return new Response<StatusDto> { Success = true, Id = unit, Message = "Created successfully!" };
            else
                return new Response<StatusDto> { Success = false, Message = "Error Creating teh resource" };
        }

        public async Task<Response<StatusDto>> Update(StatusDto dto)
        {
            var entity = await GetEntityById(dto.Id);

            if (entity == null)
            {
                return new Response<StatusDto> { Success = false, Message = "Not Found" };
            }

            entity.Name = dto.Name;

            var unit = await Update(entity);
            if (unit)
                return new Response<StatusDto> { Success = true, Message = "Updated successfully!" };
            else
                return new Response<StatusDto> { Success = false, Message = "Error Updating teh resource" };


        }


    }
}
