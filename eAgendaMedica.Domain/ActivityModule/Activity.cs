using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.ActivityModule
{
    public class Activity : Entity
    {
        public string Title { get; set; }
        public TypeActivity Type { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Doctor>? Doctors { get; set; }
        public string Theme { get; set; }

        public Activity()
        {

        }
    }
}
