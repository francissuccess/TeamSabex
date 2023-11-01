using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.Member;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMember _repo;

        public MemberController(IMember repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetMember(int pageNumber, int pageSize)
        {
            var res = await _repo.GetMember(pageNumber, pageSize);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpGet]
        public async Task<object> GetSingleMember(int Id)
        {
            var res = await _repo.GetSingleMember(Id);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("01"))
            {
                return NotFound(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateMember([FromBody] CreateMemberDto request)
        {
            var res = await _repo.CreateMember(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else if (res.Code.Equals("06"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMember([FromBody] UpdateMemberDto request)
        {
            var res = await _repo.UpdateMember(request);
            if (res.Code.Equals("00"))
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, new ErrorResponse() { Code = res.Code, description = res.Description });
            }
        }
    }
}

