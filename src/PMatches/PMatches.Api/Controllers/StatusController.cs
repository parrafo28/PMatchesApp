
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using PMatches.Domain.DTOs;
using PMatches.Domain.Entities;
using PMatches.Infrastructure.Repositories;
using PMatches.Persistence;
using PMatches.Presentation.Responses;

namespace PMatches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    { 
        private readonly StatusRepository _statusRepository;

        public StatusController( StatusRepository statusRepository)
        { 
           _statusRepository = statusRepository;
        }

        [HttpGet("Get/{id}")]
        public async Task<Response<StatusDto>> Get(int id)
        {
            return await _statusRepository.GetById(id);  
        }

        [HttpGet(nameof(GetAll))]
        public async Task<Response<List<StatusDto>>> GetAll(string filter = "")
        { 
             return await _statusRepository.GetAll(filter);
        }

        [HttpPost("Add")]
        public async Task<Response<StatusDto>> Create([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" }; 
            }

            return await _statusRepository.Create(dto); 
        }

        [HttpPut(nameof(Update))]
        public async Task<Response<StatusDto>> Update([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return new Response<StatusDto> { Success = false, Message = "The Resource is not valid" };
            }

            return await _statusRepository.Update(dto);  
        } 
    }
}