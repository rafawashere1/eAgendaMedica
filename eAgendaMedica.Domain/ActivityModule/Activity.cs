using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.ActivityModule
{
    public class Activity : Entity
    {
        public TypeActivity Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Doctor> Doctors { get; set; }

        public Activity()
        {

        }
    }
}
