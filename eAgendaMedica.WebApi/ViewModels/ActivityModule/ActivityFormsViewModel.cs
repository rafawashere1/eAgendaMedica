using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityFormsViewModel
    {
        public TypeActivity Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
