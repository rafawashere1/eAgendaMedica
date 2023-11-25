using AutoMapper;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.WebApi.Config.AutoMapperConfig.MappingActions;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityFormsViewModel, Activity>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom<UserResolver>())
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToString(@"hh\:mm")))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToString(@"hh\:mm")))
            .AfterMap<ConfigureActivityMappingAction>();


            CreateMap<Activity, ActivityFormsViewModel>()
            .ForMember(dest => dest.SelectedDoctors, opt => opt.MapFrom(src => src.Doctors.Select(doctor => doctor.Id).ToList()));


            CreateMap<Activity, ActivityDetailViewModel>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.GetDescription()))
            .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors));

            CreateMap<Activity, ActivityListViewModel>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.GetDescription()))
            .ForMember(dest => dest.SelectedDoctors, opt => opt.MapFrom(src => src.Doctors.Select(doctor => doctor.Id).ToList()));
        }
    }
}
