using AutoMapper;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityFormsViewModel, Activity>()
            .ForMember(d => d.Doctors, opt => opt.Ignore());

            CreateMap<Activity, ActivityDetailViewModel>()
            .ForMember(d => d.Doctors, opt => opt.MapFrom(o => o.Doctors.Select(x => x.Name)));

            CreateMap<Activity, ActivityListViewModel>();
        }
    }
}
