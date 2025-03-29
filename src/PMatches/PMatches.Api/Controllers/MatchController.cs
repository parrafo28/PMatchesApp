
using Microsoft.AspNetCore.Mvc;
using PMatches.Domain.DTOs;
using PMatches.Infrastructure.Repositories;
using PMatches.Presentation.Responses;

namespace PMatches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly MatchRepository _statusRepository;

        public MatchController(MatchRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet("Get/{id}")]
        public async Task<Response<MatchDto>> Get(int id)
        {
            return await _statusRepository.GetById(id);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<Response<List<MatchDto>>> GetAll(string filter = "")
        {
            return await _statusRepository.GetAll(filter);
        }

        [HttpPost("Add")]
        public async Task<Response<MatchDto>> Create([FromBody] MatchDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<MatchDto> { Success = false, Message = "The Resource is not valid" };
            }

            return await _statusRepository.Create(dto);
        }

        [HttpPut(nameof(Update))]
        public async Task<Response<MatchDto>> Update([FromBody] MatchDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<MatchDto> { Success = false, Message = "The Resource is not valid" };
            }

            return await _statusRepository.Update(dto);
        }
    }
}