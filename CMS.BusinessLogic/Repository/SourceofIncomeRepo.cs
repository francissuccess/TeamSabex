using AutoMapper;
using CMS.BusinessLogic.Interface;
using CMS.DataAccess.Database;
using CMS.Domain.Dto.SourceofIncome;
using CMS.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessLogic.Repository
{
    public class SourceofIncomeRepo : ISourceofIncome
        {
            private readonly IDbConnection _connection;
            private readonly SourceofIncomeDbService service;
            private readonly IMapper _mapper;
            public SourceofIncomeRepo(IDbConnection connection, IMapper mapper)
            {
                _connection = connection;
                _mapper = mapper;
                service = new SourceofIncomeDbService(connection);
            }
            public async Task<APIResponse<CreateSourceofIncomeDto>> CreateSourceofIncome(CreateSourceofIncomeDto request)
        {
            var response = new APIResponse<CreateSourceofIncomeDto>();
            var model = _mapper.Map<SourceofIncome>(request);
            var result = await service.CreateSourceofIncome(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else if (result == -1)
            {
                response.Code = "01";
                response.Description = "Record Already Exist";
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occuried, Please try again later";
            }
            return response;
        }


        public async Task<APIResponse<SourceofIncome>> GetSingleSourceofIncome(int Id)
        {
            var response = new APIResponse<SourceofIncome>();
            var result = await service.SingleSourceofIncome(Id);

            if (result != null)
            {
                if (result.Id == 0)
                {
                    response.Code = "01";
                    response.Description = "No Record found";
                }
                else
                {
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result;
                }
            }
            else
            {
                response.Code = "01";
                response.Description = "No Record found";
            }
            return response;
        }



        public async Task<APIListResponse3<SourceofIncome>> GetSourceofIncome(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<SourceofIncome>();
            var result = await service.GetSourceofIncomes(pageNumber, pageSize);
            if (result != null)
            {
                if (result.Data.Count() > 0)
                {
                    var metadata = new
                    {
                        result.Data.TotalCount,
                        result.Data.PageSize,
                        result.Data.CurrentPage,
                        result.Data.TotalPages,
                        result.Data.HasNext,
                        result.Data.HasPrevious
                    };
                    response.PageInfo = JsonConvert.SerializeObject(metadata);
                    response.Code = "00";
                    response.Description = "Successful";
                    response.Data = result.Data;
                }
                else
                {
                    response.Code = "01";
                    response.Description = "No Record Found";
                }
            }
            else
            {
                response.Code = "99";
                response.Description = "An Error Occured, Please try again later";
            }
            return response;
        }

        public async Task<APIResponse<UpdateSourceofIncomeDto>> UpdateSourceofIncome(UpdateSourceofIncomeDto request)
        {
            var response = new APIResponse<UpdateSourceofIncomeDto>();
            var model = _mapper.Map<SourceofIncome>(request);
            var result = await service.UpdateSourceofIncome(model);

            if (result == 1)
            {
                response.Code = "00";
                response.Description = "Successful";
                response.Data = request;
            }
            else
            {
                response.Code = "99";
                response.Description = "An error occured, Please try again later";
            }
            return response;
        }
    }
}

