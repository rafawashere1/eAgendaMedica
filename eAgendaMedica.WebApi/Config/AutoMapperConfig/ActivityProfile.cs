using AutoMapper;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityFormsViewModel, Activity>();
            CreateMap<Activity, ActivityDetailViewModel>();
            CreateMap<Activity, ActivityListViewModel>();
        }
    }
}
