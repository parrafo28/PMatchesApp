using PMatches.Domain.DTOs;
using PMatches.Presentation.Responses;

namespace PMatches.Application.Contracts
{
    public interface IStatusService
    {
        Task<Response<StatusDto>> GetStatusById(int id);

        Task<Response<List<StatusDto>>> GetAllStatus(string filter = "");


        Task<Response<StatusDto>> CreateStatus(StatusDto dto);


        Task<Response<StatusDto>> UpdateStatus(StatusDto dto);

    }
}
