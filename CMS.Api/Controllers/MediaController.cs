using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.Media;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMedia _repo;

        public MediaController(IMedia repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetMedia(int pageNumber, int pageSize)
        {
            var res = await _repo.GetMedia(pageNumber, pageSize);
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
        public async Task<object> GetSingleMedia(int Id)
        {
            var res = await _repo.GetSingleMedia(Id);
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
        public async Task<ActionResult> CreateMedia([FromBody] CreateMediaDto request)
        {
            var res = await _repo.CreateMedia(request);
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
        public async Task<ActionResult> UpdateMedia([FromBody] UpdateMediaDto request)
        {
            var res = await _repo.UpdateMedia(request);
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

