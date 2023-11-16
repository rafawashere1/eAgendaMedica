﻿using AutoMapper;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorFormsViewModel, Doctor>()
            .ForMember(d => d.CurrentActivity, opt => opt.Ignore());

            CreateMap<Doctor, DoctorListViewModel>();

            CreateMap<Doctor, DoctorDetailViewModel>()
            .ForMember(d => d.LastActivity, opt => opt.MapFrom(o => o.LastActivity.ToShortDateString()));

            CreateMap<Doctor, SelectedDoctorViewModel>();
        }
    }
}