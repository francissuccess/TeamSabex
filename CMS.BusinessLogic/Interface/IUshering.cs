using CMS.Domain.Dto.Media;
using CMS.Domain.Dto.Ushering;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Interface
{
    public interface IUshering
    {
        Task<APIListResponse3<Ushering>> GetUshering(int pageNumber, int pageSize);
        Task<APIResponse<Ushering>> GetSingleUshering(int Id);
        Task<APIResponse<CreateUsheringDto>> CreateUshering(CreateUsheringDto request);
        Task<APIResponse<UpdateUsheringDto>> UpdateUshering(UpdateUsheringDto request);
    }
}
