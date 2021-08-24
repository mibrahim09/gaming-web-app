using AutoMapper;
using NovaGaming.Dtos;
using NovaGaming.sakila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaGaming
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDto, Account>();
            CreateMap<Account, LoginDto>();

            CreateMap<RegisterDto, Account>();
            CreateMap<Account, RegisterDto>();

            CreateMap<ProfileCharacterDto, Character>();
            CreateMap<Character, ProfileCharacterDto>();

            CreateMap<ProfileTransactionsDto, Payment>();
            CreateMap<Payment, ProfileTransactionsDto>();

            CreateMap<ProfileUserDto, Account>();
            CreateMap<Account, ProfileUserDto>();
        }
    }
}
