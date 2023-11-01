using AutoMapper;
using CMS.BusinessLogic.Interface;
using CMS.DataAccess.Database;
using CMS.Domain.Dto.Media;
using CMS.Domain.Dto.Member;
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
    public class MediaRepo : IMedia
    {
        
        private readonly IDbConnection _connection;
        private readonly MediaDbService service;
        private readonly IMapper _mapper;
        public MediaRepo(IDbConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
            service = new MediaDbService(connection);
        }
        public async Task<APIResponse<CreateMediaDto>> CreateMedia(CreateMediaDto request)
        {
            var response = new APIResponse<CreateMediaDto>();
            var model = _mapper.Map<Media>(request);
            var result = await service.CreateMedia(model);

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

        public async Task<APIListResponse3<Media>> GetMedia(int pageNumber, int pageSize)
        {
            var response = new APIListResponse3<Media>();
            var result = await service.GetMedias(pageNumber, pageSize);
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


        public async Task<APIResponse<Media>> GetSingleMedia(int Id)
        {
            var response = new APIResponse<Media>();
            var result = await service.SingleMedia(Id);

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



        public async Task<APIResponse<UpdateMediaDto>> UpdateMedia(UpdateMediaDto request)
        {
            var response = new APIResponse<UpdateMediaDto>();
            var model = _mapper.Map<Media>(request);
            var result = await service.UpdateMedia(model);

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