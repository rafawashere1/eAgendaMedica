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
            .ForMember(d => d.Doctors, opt => opt.Ignore())
            .ForMember(d => d.StartTime, opt => opt.MapFrom(o => o.StartTime.ToString(@"hh\:mm")))
            .ForMember(d => d.EndTime, opt => opt.MapFrom(o => o.EndTime.ToString(@"hh\:mm")))
            .AfterMap<ConfigureActivityMappingAction>();

            CreateMap<Activity, ActivityFormsViewModel>()
            .ForMember(d => d.Type, opt => opt.MapFrom(o => o.Type.GetDescription()));


            CreateMap<Activity, ActivityDetailViewModel>()
            .ForMember(d => d.Type, opt => opt.MapFrom(o => o.Type.GetDescription()))
            .ForMember(d => d.Doctors, opt => opt.MapFrom(o => o.Doctors));

            CreateMap<Activity, ActivityListViewModel>()
            .ForMember(d => d.Type, opt => opt.MapFrom(o => o.Type.GetDescription()));
        }
    }
}
