using AutoMapper;
using CMS.Domain.Dto.Choir;
using CMS.Domain.Dto.Media;
using CMS.Domain.Dto.Member;
using CMS.Domain.Dto.Pastor;
using CMS.Domain.Dto.SourceofIncome;
using CMS.Domain.Dto.Ushering;
using CMS.Domain.Dtos.Account;
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

            CreateMap<User, UserDto>();
            CreateMap<User, RegistrationDto>();

            CreateMap<Member, CreateMemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<Member, UpdateMemberDto>();
            CreateMap<UpdateMemberDto, Member>();

            CreateMap<Media, CreateMediaDto>();
            CreateMap<CreateMediaDto, Media>();
            CreateMap<Media, UpdateMediaDto>();
            CreateMap<UpdateMediaDto, Media>();

            CreateMap<Ushering, CreateUsheringDto>();
            CreateMap<CreateUsheringDto, Ushering>();
            CreateMap<Ushering, UpdateMediaDto>();
            CreateMap<UpdateUsheringDto, Ushering>();
        }
    }
}
