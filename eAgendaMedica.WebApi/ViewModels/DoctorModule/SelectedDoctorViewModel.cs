namespace eAgendaMedica.WebApi.ViewModels.DoctorModule
{
    public class SelectedDoctorViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
