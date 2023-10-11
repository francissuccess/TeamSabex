using AutoMapper;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Models;

namespace CMS.Api.Extension
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Pastor, CreatePastorDto>();
            CreateMap<CreatePastorDto, Pastor>();
            CreateMap<Pastor, UpdatePastorDto>();
            CreateMap<UpdatePastorDto, Pastor>();

        }
    }
}
