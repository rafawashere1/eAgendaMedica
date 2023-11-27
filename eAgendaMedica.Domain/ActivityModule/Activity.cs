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

        public Activity(string title, TypeActivity type, DateTime startDay, DateTime endDay, TimeSpan startTime, TimeSpan endTime, List<Doctor>? doctors, string theme)
        {
            Title = title;
            Type = type;
            StartDay = startDay;
            EndDay = endDay;
            StartTime = startTime;
            EndTime = endTime;
            Doctors = doctors;
            Theme = theme;
        }

        public Activity(string title, TypeActivity type, DateTime startDay, DateTime endDay, TimeSpan startTime, TimeSpan endTime, string theme)
        {
            Title = title;
            Type = type;
            StartDay = startDay;
            EndDay = endDay;
            StartTime = startTime;
            EndTime = endTime;
            Theme = theme;
        }

        public static void SetDays(Activity activity)
        {
            activity.StartDay = activity.StartDay.Date.Add(activity.StartTime);
            activity.EndDay = activity.EndDay.Date.Add(activity.EndTime);
        }
    }
}
