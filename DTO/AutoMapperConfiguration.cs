using AutoMapper;
using Filters.Models;

namespace Filters.DTO
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            //CreateMap<ApplicationUser, UserDetails>();
            //CreateMap<UserDetails,ApplicationUser>();
            CreateMap<UserDetails, ApplicationUser>().ReverseMap();
        }
    }
}
