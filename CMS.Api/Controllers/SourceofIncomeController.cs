
using CMS.BusinessLogic.Interface;
using CMS.Domain.Dto.SourceofIncome;
using CMS.Domain.Models;
using Microsoft.AspNetCore.Mvc;
namespace CMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SourceofIncomeController : ControllerBase
    {
        private readonly ISourceofIncome _repo;
        public SourceofIncomeController(ISourceofIncome repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<object> GetSourceofIncome(int pageNumber, int pageSize)
        {
            var res = await _repo.GetSourceofIncome(pageNumber, pageSize);
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
        public async Task<object> GetSingleSourceofIncome(int Id)
        {
            var res = await _repo.GetSingleSourceofIncome(Id);
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
        public async Task<ActionResult> CreateSourceofIncome([FromBody] CreateSourceofIncomeDto request)
        {
            var res = await _repo.CreateSourceofIncome(request);
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
        public async Task<ActionResult> UpdateSourceofIncome([FromBody] UpdateSourceofIncomeDto request)
        {
            var res = await _repo.UpdateSourceofIncome(request);
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


