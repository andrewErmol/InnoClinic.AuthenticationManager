using AuthenticationManager.BLL.Models;
using AuthenticationManager.DAL.Entity;
using AutoMapper;

namespace AuthenticationManager.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForCreation, Account>();
        }
    }
}
