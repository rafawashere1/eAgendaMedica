using AutoMapper;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorFormsViewModel, Doctor>()
            .ForMember(dest => dest.Activities, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.MapFrom<UserResolver>());

            CreateMap<Doctor, DoctorFormsViewModel>();

            CreateMap<Doctor, DoctorListViewModel>();

            CreateMap<Doctor, DoctorDetailViewModel>();

            CreateMap<Doctor, SelectedDoctorViewModel>();
        }
    }
}
