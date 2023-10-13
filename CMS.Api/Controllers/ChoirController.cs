using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.Choir;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChoirController : ControllerBase
    {
        private readonly IChoir _repo;



        public ChoirController(IChoir repo)
        {
            _repo = repo;
        }





        [HttpGet]
        public async Task<object> GetChoir(int pageNumber, int pageSize)
        {
            var res = await _repo.GetChoir(pageNumber, pageSize);
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
        public async Task<object> GetSingleChoir(int Id)
        {
            var res = await _repo.GetSingleChoir(Id);
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
        public async Task<ActionResult> CreateChoir([FromBody] CreateChoirDto request)
        {
            var res = await _repo.CreateChoir(request);
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
        public async Task<ActionResult> UpdateChoir([FromBody] UpdateChoirDto request)
        {
            var res = await _repo.UpdateChoir(request);
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
