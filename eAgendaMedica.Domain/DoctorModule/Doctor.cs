using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;
using System.Numerics;

namespace eAgendaMedica.Domain.DoctorModule
{
    public class Doctor : Entity
    {
        public string CRM { get; set; }
        public string Name { get; set; }
        public DateTime LastActivity { get; set; }
        public List<Activity> Activities { get; set; }

        public Doctor()
        {

        }

        public Doctor(string cRM, string name, DateTime lastActivity, List<Activity> activities)
        {
            CRM = cRM;
            Name = name;
            LastActivity = lastActivity;
            Activities = activities;
        }

        public override bool Equals(object? obj)
        {
            return obj is Doctor doctor &&
                   Id.Equals(doctor.Id) &&
                   CRM == doctor.CRM &&
                   Name == doctor.Name &&
                   LastActivity == doctor.LastActivity &&
                   EqualityComparer<List<Activity>>.Default.Equals(Activities, doctor.Activities);
        }

        public bool AreEqual(object? obj)
        {
            return obj is Doctor doctor &&
                   CRM == doctor.CRM &&
                   Name == doctor.Name &&
                   LastActivity == doctor.LastActivity &&
                   EqualityComparer<List<Activity>>.Default.Equals(Activities, doctor.Activities);
        }
    }
}
