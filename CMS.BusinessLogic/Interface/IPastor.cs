using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;

namespace CMS.BusinessLogic.Interface
{
    public interface IPastor
    {
        Task<APIListResponse3<Pastor>> GetPastor(int pageNumber, int pageSize);
        Task<APIResponse<Pastor>> GetSinglePastor(int Id);
        Task<APIResponse<CreatePastorDto>> CreatePastor(CreatePastorDto request);
        Task<APIResponse<UpdatePastorDto>> UpdatePastor(UpdatePastorDto request);
    }
}
