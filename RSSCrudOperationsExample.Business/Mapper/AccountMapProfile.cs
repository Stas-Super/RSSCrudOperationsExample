using AutoMapper;
using RSSCrudOperationsExample.Business.Dtos.Account;
using RSSCrudOperationsExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSCrudOperationsExample.Business.Mapper
{
    /// <summary>
    /// Account auto mapper
    /// </summary>
    public class AccountMapProfile : Profile
    {
        public AccountMapProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(user => user.Id, options => options.Ignore())
                .ForMember(user => user.Email, options => options.MapFrom(dto => dto.Email))
                .ForMember(user => user.EmailConfirmed, options => options.Ignore())
                .ForMember(user => user.PhoneNumber, options => options.Ignore())
                .ForMember(user => user.UserName, options => options.MapFrom(dto => dto.UserName))
                .ForMember(user => user.NormalizedUserName, options => options.MapFrom(dto => dto.UserName.Normalize()))
                .ForMember(user => user.NormalizedEmail, options => options.MapFrom(dto => dto.Email.Normalize()));
            CreateMap<User, UserResponseDto>()
                .ForMember(userResponseDto => userResponseDto.User, options => options.MapFrom(user => user))
                .ForMember(userResponseDto => userResponseDto.AccessToken, options => options.Ignore())
                .ForMember(userResponseDto => userResponseDto.RefreshToken, options => options.Ignore());
        }
    }
}
