using eAgendaMedica.Domain.ActivityModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityFormsViewModel
    {
        public TypeActivity Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Guid> SelectedDoctors { get; set; }
    }
}
