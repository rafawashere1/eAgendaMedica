using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.DoctorModule
{
    public class Doctor : Entity
    {
        public string CRM { get; set; }

        public string Name { get; set; }

        public DateTime LastActivity { get; set; }

        public Activity? Activity { get; set; }

        public Doctor()
        {
            
        }

        public bool CanDoActivity()
        {
            TimeSpan cooldown = Activity.TypeActivity == TypeActivity.Surgery ? TimeSpan.FromHours(4) : TimeSpan.FromMinutes(20);

            TimeSpan difference = DateTime.Now - LastActivity;

            return difference >= cooldown;
        }
    }
}
