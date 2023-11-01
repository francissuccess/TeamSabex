using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.Member;
using CMS.Domain.Dto.Ushering;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsheringController : ControllerBase
    {
        private readonly IUshering _repo;

        public UsheringController(IUshering repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetUshering(int pageNumber, int pageSize)
        {
            var res = await _repo.GetUshering(pageNumber, pageSize);
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
        public async Task<object> GetSingleUshering(int Id)
        {
            var res = await _repo.GetSingleUshering(Id);
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
        public async Task<ActionResult> CreateUshering([FromBody] CreateUsheringDto request)
        {
            var res = await _repo.CreateUshering(request);
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
        public async Task<ActionResult> UpdateUshering([FromBody] UpdateUsheringDto request)
        {
            var res = await _repo.UpdateUshering(request);
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

