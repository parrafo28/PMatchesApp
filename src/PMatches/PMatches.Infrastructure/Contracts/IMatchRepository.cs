using PMatches.Domain.DTOs;
using PMatches.Presentation.Responses;

namespace PMatches.Infrastructure.Repositories
{
    public interface IMatchRepository
    {
        Task<Response<MatchDto>> Create(MatchDto dto);
        Task<Response<List<MatchDto>>> GetAll(string filter = "");
        Task<Response<MatchDto>> GetById(int id);
        Task<Response<MatchDto>> Update(MatchDto dto);
    }
}