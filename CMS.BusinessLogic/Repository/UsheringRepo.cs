using AutoMapper;
using CMS.BusinessLogic.Interface;
using CMS.DataAccess.Database;
using CMS.Domain.Dto.Media;
using CMS.Domain.Dto.Member;
using CMS.Domain.Dto.Ushering;
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
    public class UsheringRepo : IUshering
    {

        private readonly IDbConnection _connection;
        private readonly UsheringDbService service;
        private readonly IMapper _mapper;
        public UsheringRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new UsheringDbService(connection);
        }
        public async Task<APIResponse<CreateUsheringDto>> CreateUshering(CreateUsheringDto request)
        {
            var response = new APIResponse<CreateUsheringDto>();
            var model = _mapper.Map<Ushering>(request);
            var result = await service.CreateUshering(model);

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


        public async Task<APIResponse<Ushering>> GetSingleUshering(int Id)
        {
            var response = new APIResponse<Ushering>();
            var result = await service.SingleUshering(Id);

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



        public async Task<APIListResponse3<Ushering>> GetUshering(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Ushering>();
            var result = await service.GetUsherings(pageNumber, pageSize);
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


        public async Task<APIResponse<UpdateUsheringDto>> UpdateUshering(UpdateUsheringDto request)
        {
            var response = new APIResponse<UpdateUsheringDto>();
            var model = _mapper.Map<Ushering>(request);
            var result = await service.UpdateUshering(model);

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