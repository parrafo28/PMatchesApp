
using Microsoft.AspNetCore.Mvc;
using PMatches.Domain.DTOs;
using PMatches.Infrastructure.Core;
using PMatches.Infrastructure.Repositories;
using PMatches.Presentation.Responses;

namespace PMatches.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly UnitOfWork _unitOfWork;

        public StatusController(IStatusRepository statusRepository, UnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
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
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = await _statusRepository.Create(dto);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();
                return result;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(); 
                throw;
            }

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