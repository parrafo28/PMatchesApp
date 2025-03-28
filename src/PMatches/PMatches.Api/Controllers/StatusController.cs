
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMatches.Api.Dtos;
using PMatches.Domain.Entities;
using PMatches.Persistence;
using PMatches.Presentation.Responses;

namespace PMatches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get/{id}")]
        public async Task<Response<StatusDto>> Get(int id)
        {
            var status = await _context.Status.FindAsync(id);
      
            if (status == null)
            {
               return  new Response<StatusDto> { Success = false, Message = "Not Found" }; 
            }
        
            var statusResponse = new StatusDto();
           
            statusResponse.Name = status.Name;
            statusResponse.Id = status.Id;
     
            return new Response<StatusDto> { Success = true, Data = statusResponse };

        }

        [HttpGet(nameof(GetAll))]
        public async Task<Response<List<StatusDto>>> GetAll(string filter = "")
        {
            var list = _context.Status.Include(p => p.Matches).Where(P => P.Id > 0);

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

        [HttpPost("Add")]
        public async Task<Response<StatusDto>> Create([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" }; 
            }

            var entity = new Status { Name = dto.Name };
            _context.Status.Add(entity);
            await _context.SaveChangesAsync();
          
            return new Response<StatusDto> { Success = true, Message = "Created successfully!" };

        }

        [HttpPut(nameof(Update))]
        public async Task<Response<StatusDto>> Update([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" };
            }
            
            var status = await _context.Status.FindAsync(dto.Id);
            if (status == null)
            {
                return new Response<StatusDto> { Success = false, Message = "Not Found" };
            }

            status.Name = dto.Name;

            _context.Status.Update(status);
            await _context.SaveChangesAsync(); 

            return new Response<StatusDto> { Success = true, Message = "Updated successfully!" };

        }



    }
}
