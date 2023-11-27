using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.AuthModule;
using eAgendaMedica.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace eAgendaMedica.Domain.DoctorModule
{
    public class Doctor : Entity
    {
        public string CRM { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }

        [NotMapped]
        public TimeSpan WorkedHours { get; set; }

        public Doctor()
        {

        }

        public Doctor(string cRM, string name, List<Activity> activities)
        {
            CRM = cRM;
            Name = name;
            Activities = activities;
        }

        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor &&
                   Id.Equals(doctor.Id) &&
                   CRM == doctor.CRM &&
                   Name == doctor.Name &&
                   EqualityComparer<List<Activity>>.Default.Equals(Activities, doctor.Activities);
        }

        public bool AreEqual(object? obj)
        {
            return obj is Doctor doctor &&
                   CRM == doctor.CRM &&
                   Name == doctor.Name &&
                   EqualityComparer<List<Activity>>.Default.Equals(Activities, doctor.Activities);
        }

        public static List<Doctor> CalculateHoursWorked(List<Doctor> doctors)
        {
            if (doctors == null)
                return null;

            foreach (var doctor in doctors)
            {
                foreach (var activity in doctor.Activities)
                {
                    TimeSpan duration = activity.EndDay - activity.StartDay;

                    doctor.WorkedHours += duration;
                }
            }

            return doctors.OrderByDescending(d => d.WorkedHours)
                          .ThenBy(d => d.WorkedHours == TimeSpan.Zero)
                          .Take(10)
                          .ToList();
        }

        public static bool CanDoActivity(Activity newActivity)
        {
            if (newActivity.Doctors == null)
                return false;

            foreach (var doctor in newActivity.Doctors)
            {
                if (!doctor.HasSufficientRecoveryTime(newActivity))
                {
                    return false;
                }

                if (doctor.HasScheduleConflict(newActivity))
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasScheduleConflict(Activity newActivity)
        {
            if (Activities != null)
            {
                foreach (var activity in Activities)
                {

                    if (activity == newActivity)
                    {
                        continue;
                    }

                    if (IsScheduleConflict(activity, newActivity))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasSufficientRecoveryTime(Activity newActivity)
        {
            if (Activities != null && Activities.Any())
            {
                foreach (var activity in Activities)
                {
                    if (activity == newActivity)
                    {
                        continue;
                    }

                    var recoveryTime = GetRecoveryTime(activity.Type);

                    if (activity.EndDay.Add(recoveryTime) > newActivity.StartDay)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsScheduleConflict(Activity existingActivity, Activity newActivity)
        {
            return (existingActivity.StartDay < newActivity.EndDay) &&
                   (existingActivity.EndDay > newActivity.StartDay);
        }

        private static TimeSpan GetRecoveryTime(TypeActivity activityType)
        {
            return activityType == TypeActivity.Surgery ? TimeSpan.FromHours(4) : TimeSpan.FromMinutes(20);
        }
    }
}
