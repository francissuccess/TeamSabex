using AutoMapper;
using CMS.BusinessLogic.Interface;
using CMS.DataAccess.Database;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;
using Newtonsoft.Json;
using System.Data;


namespace CMS.BusinessLogic.Repository
{
    public class PastorRepo : IPastor
    {
        private readonly IDbConnection _connection;
        private readonly PastorDbService service;
        private readonly IMapper _mapper;
        public PastorRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new PastorDbService(connection);
        }
        public async Task<APIResponse<CreatePastorDto>> CreatePastor(CreatePastorDto request)
        {
            var response = new APIResponse<CreatePastorDto>();
            var model = _mapper.Map<Pastor>(request);
            var result = await service.CreatePastor(model);

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

        public async Task<APIListResponse3<Pastor>> GetPastor(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Pastor>();
            var result = await service.GetPastors(pageNumber, pageSize);
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

        public async Task<APIResponse<Pastor>> GetSinglePastor(int Id)
        {
            var response = new APIResponse<Pastor>();
            var result = await service.SinglePastor(Id);

            if (result != null)
            {
                if (result.id == 0)
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



        public async Task<APIResponse<UpdatePastorDto>> UpdatePastor(UpdatePastorDto request)
        {
            var response = new APIResponse<UpdatePastorDto>();
            var model = _mapper.Map<Pastor>(request);
            var result = await service.UpdatePastor(model);

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
