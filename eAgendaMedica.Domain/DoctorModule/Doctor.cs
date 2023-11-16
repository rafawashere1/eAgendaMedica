using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.DoctorModule
{
    public class Doctor : Entity
    {
        public string CRM { get; set; }
        public string Name { get; set; }
        public DateTime LastActivity { get; set; }
        public Activity CurrentActivity { get; set; }
        public Guid? CurrentActivityId { get; set; }

        public Doctor()
        {

        }

        public bool CanDoActivity()
        {
            TimeSpan cooldown = CurrentActivity.Type == TypeActivity.Surgery ? TimeSpan.FromHours(4) : TimeSpan.FromMinutes(20);

            TimeSpan difference = DateTime.Now - LastActivity;

            return difference >= cooldown;
        }
    }
}
