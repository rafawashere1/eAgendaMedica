using AutoMapper;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.WebApi.ViewModels.AuthModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));
        }
    }
}
