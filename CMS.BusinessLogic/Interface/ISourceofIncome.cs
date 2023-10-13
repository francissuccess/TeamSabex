using CMS.Domain.Dto.SourceofIncome;
using CMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Interface
{
    public interface ISourceofIncome
    {
        Task<APIListResponse3<SourceofIncome>> GetSourceofIncome(int pageNumber, int pageSize);
        Task<APIResponse<SourceofIncome>> GetSingleSourceofIncome(int Id);
        Task<APIResponse<CreateSourceofIncomeDto>> CreateSourceofIncome(CreateSourceofIncomeDto request);
        Task<APIResponse<UpdateSourceofIncomeDto>> UpdateSourceofIncome(UpdateSourceofIncomeDto request);
    }
}
