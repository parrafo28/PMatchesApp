using PMatches.Domain.DTOs;
using PMatches.Presentation.Responses;

namespace PMatches.Infrastructure.Repositories
{
    public interface IStatusRepository
    {
        Task<Response<StatusDto>> Create(StatusDto dto);
        Task<Response<List<StatusDto>>> GetAll(string filter = "");
        Task<Response<StatusDto>> GetById(int id);
        Task<Response<StatusDto>> Update(StatusDto dto);
    }
}