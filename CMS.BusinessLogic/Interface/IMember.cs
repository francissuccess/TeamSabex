using CMS.Domain.Dto.Member;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Interface
{
    public interface IMember
    {
        Task<APIListResponse3<Member>> GetMember(int pageNumber, int pageSize);
        Task<APIResponse<Member>> GetSingleMember(int Id);
        Task<APIResponse<CreateMemberDto>> CreateMember(CreateMemberDto request);
        Task<APIResponse<UpdateMemberDto>> UpdateMember(UpdateMemberDto request);
    }
}
