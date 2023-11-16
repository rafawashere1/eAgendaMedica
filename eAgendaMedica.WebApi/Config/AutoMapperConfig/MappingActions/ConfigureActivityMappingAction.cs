using AutoMapper;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig.MappingActions
{
    public class ConfigureActivityMappingAction : IMappingAction<ActivityFormsViewModel, Activity>
    {
        private readonly IDoctorRepository _doctorRepository;

        public ConfigureActivityMappingAction(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void Process(ActivityFormsViewModel source, Activity destination, ResolutionContext context)
        {
            destination.Doctors = _doctorRepository.GetMany(source.SelectedDoctors);
        }
    }
}
