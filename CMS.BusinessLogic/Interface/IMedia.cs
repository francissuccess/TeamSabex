using CMS.Domain.Dto.Media;
using CMS.Domain.Dto.Member;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Interface
{
    public interface IMedia
    {
        Task<APIListResponse3<Media>> GetMedia(int pageNumber, int pageSize);
        Task<APIResponse<Media>> GetSingleMedia(int Id);
        Task<APIResponse<CreateMediaDto>> CreateMedia(CreateMediaDto request);
        Task<APIResponse<UpdateMediaDto>> UpdateMedia(UpdateMediaDto request);
    }
}
