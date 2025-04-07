
using Microsoft.AspNetCore.Mvc;
using PMatches.Application.Contracts;
using PMatches.Domain.DTOs;
using PMatches.Presentation.Responses;

namespace PMatches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("Get/{id}")]
        public async Task<Response<StatusDto>> Get(int id)
        {
            return await _statusService.GetStatusById(id);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<Response<List<StatusDto>>> GetAll(string filter = "")
        {
            return await _statusService.GetAllStatus(filter);
        }

        [HttpPost("Add")]
        public async Task<Response<StatusDto>> Create([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" };
            }
            return await _statusService.CreateStatus(dto);

        }

        [HttpPut(nameof(Update))]
        public async Task<Response<StatusDto>> Update([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" };
            }

            return await _statusService.UpdateStatus(dto);
        }
    }
}