using PMatches.Application.Contracts;
using PMatches.Domain.DTOs;
using PMatches.Infrastructure.Contracts;
using PMatches.Infrastructure.Core;
using PMatches.Infrastructure.Repositories;
using PMatches.Presentation.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMatches.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<StatusDto>> CreateStatus(StatusDto dto)
        {
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

        public async Task<Response<List<StatusDto>>> GetAllStatus(string filter = "")
        {
            return await _statusRepository.GetAll(filter); 
        }

        public async Task<Response<StatusDto>> GetStatusById(int id)
        {
            return await _statusRepository.GetById(id);

        }

        public async Task<Response<StatusDto>> UpdateStatus(StatusDto dto)
        {
            return await _statusRepository.Update(dto); 
        }
    }
}
