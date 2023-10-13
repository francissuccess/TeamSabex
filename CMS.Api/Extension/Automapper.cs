using AutoMapper;
using CMS.Domain.Dto.Choir;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Dto.SourceofIncome;
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

            CreateMap<Choir, CreateChoirDto>();
            CreateMap<CreateChoirDto, Choir>();
            CreateMap<Choir, UpdateChoirDto>();
            CreateMap<UpdateChoirDto, Choir>();

            CreateMap<SourceofIncome, CreateSourceofIncomeDto>();
            CreateMap<CreateSourceofIncomeDto, SourceofIncome>();
            CreateMap<SourceofIncome, UpdateSourceofIncomeDto>();
            CreateMap<UpdateSourceofIncomeDto, SourceofIncome>();

        }
    }
}
