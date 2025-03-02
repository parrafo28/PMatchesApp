using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMatches.Api.Dtos;
using PMatches.Domain.Entities;
using PMatches.Persistence;

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
        public async Task<IActionResult> Get(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return BadRequest("Not found");
            }
            return Ok(status);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<List<StatusDto>> GetAll(string filter = "")
        {
            var list = _context.Status.Include(p=> p.Matches).Where(P => P.Id > 0);

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
             
            return response;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }

            var entity = new Status { Name = dto.Name };
            _context.Status.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Created successfully!" });
        }


    }
}
