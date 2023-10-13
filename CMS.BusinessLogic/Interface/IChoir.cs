using CMS.Domain.Dto.Choir;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Interface
{
    public interface IChoir
    {
        Task<APIListResponse3<Choir>> GetChoir(int pageNumber, int pageSize);
        Task<APIResponse<Choir>> GetSingleChoir(int Id);
        Task<APIResponse<CreateChoirDto>> CreateChoir(CreateChoirDto request);
        Task<APIResponse<UpdateChoirDto>> UpdateChoir(UpdateChoirDto request);
    }
}
