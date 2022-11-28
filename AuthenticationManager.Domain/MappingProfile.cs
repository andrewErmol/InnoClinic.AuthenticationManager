using AuthenticationManager.Domain.Models;
using AuthenticationManager.DTO.Account;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForCreationDto, Account>();
        }
    }
}
