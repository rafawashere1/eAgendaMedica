using eAgendaMedica.WebApi.ViewModels.ActivityModule;

namespace eAgendaMedica.WebApi.ViewModels.DoctorModule
{
    public class DoctorDetailViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Name { get; set; }
        public List<ActivityListViewModel> Activities { get; set; }
        public TimeSpan WorkedHours { get; set; }
    }
}
