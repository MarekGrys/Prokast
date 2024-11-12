using AutoMapper;
using Prokast.Server.Entities;

namespace Prokast.Server.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Registration, Clients>();
            CreateMap<Registration, AccountLogIn>();
            
        }
    }
}
