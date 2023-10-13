using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PastorController : ControllerBase
    {
        private readonly IPastor _repo;

        public PastorController(IPastor repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<object> GetPastor(int pageNumber, int pageSize)
        {
            var res = await _repo.GetPastor(pageNumber, pageSize);
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
        public async Task<object> GetSinglePastor(int Id)
        {
            var res = await _repo.GetSinglePastor(Id);
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
        public async Task<ActionResult> CreatePastor([FromBody] CreatePastorDto request)
        {
            var res = await _repo.CreatePastor(request);
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
        public async Task<ActionResult> UpdatePastor([FromBody] UpdatePastorDto request)
        {
            var res = await _repo.UpdatePastor(request);
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

