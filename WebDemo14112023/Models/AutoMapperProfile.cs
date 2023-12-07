using AutoMapper;
using DatabaseFirstDemo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDemo14112023.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(destination => destination.UserName,
options => options.MapFrom(source => source.UserName))
                .ForMember(destination => destination.UserName,
options => options.Condition(source => source.UserName
!= source.UserName)).ReverseMap();



        }
    }
}
