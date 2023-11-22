using eAgendaMedica.WebApi.ViewModels.DoctorModule;

namespace eAgendaMedica.WebApi.ViewModels.ActivityModule
{
    public class ActivityDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<DoctorListViewModel> Doctors { get; set; }
    }
}
