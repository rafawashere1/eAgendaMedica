using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityFormsViewModel
    {
        public string Title { get; set; }
        public TypeActivity Type { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Theme { get; set; }
        public List<Guid> SelectedDoctors { get; set; }
    }
}
