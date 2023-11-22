using eAgendaMedica.Domain.ActivityModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityListViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
