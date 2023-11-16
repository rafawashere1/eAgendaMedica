using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Activity = eAgendaMedica.Domain.ActivityModule.Activity;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor
            {
                CRM = "23347-SP",
                Name = "Dr. Exemplo4",
                CurrentActivity = new Activity(),
                CurrentActivityId = Guid.NewGuid()
            };

            Doctor doctor2 = new Doctor
            {
                CRM = "24547-SP",
                Name = "Dr. Exemplo5",
                CurrentActivity = new Activity(),
                CurrentActivityId = Guid.NewGuid()
            };

            var activity = new Activity
            {
                Type = TypeActivity.Surgery,
                StartTime = TimeSpan.FromHours(9),
                EndTime = TimeSpan.FromHours(17),
                Doctors = new List<Doctor> { doctor, doctor2 },
            };

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);

            dbContext.Add(doctor);
            dbContext.Add(activity);

            dbContext.SaveChanges();
        }
    }
}