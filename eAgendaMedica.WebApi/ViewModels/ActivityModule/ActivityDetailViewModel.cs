using eAgendaMedica.Domain.ActivityModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityDetailViewModel
    {
        public Guid Id { get; set; }
        public TypeActivity Type { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> Doctors { get; set; }
    }
}
