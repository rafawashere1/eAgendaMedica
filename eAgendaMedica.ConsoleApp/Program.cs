using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Taikandi;
using Activity = eAgendaMedica.Domain.ActivityModule.Activity;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();

            // Display the generated GUIDs
            Console.WriteLine($"Guid 1: {guid1}");
            Console.WriteLine($"Guid 2: {guid2}");
            Console.WriteLine($"Guid 3: {guid3}");

            Guid sequentialGuid1 = SequentialGuid.NewGuid();
            Guid sequentialGuid2 = SequentialGuid.NewGuid();
            Guid sequentialGuid3 = SequentialGuid.NewGuid();

            // Display the generated sequential GUIDs
            Console.WriteLine($"Sequential Guid 1: {sequentialGuid1}");
            Console.WriteLine($"Sequential Guid 2: {sequentialGuid2}");
            Console.WriteLine($"Sequential Guid 3: {sequentialGuid3}");

            var doctor = new Doctor
            {
                CRM = "23347-SP",
                Name = "Dr Exemplo4",
                Activities = new List<Activity>(),
            };

            var doctor2 = new Doctor
            {
                CRM = "24547-SP",
                Name = "Dr Exemplo5",
                Activities = new List<Activity>(),
            };

            var activity = new Activity
            {
                Type = TypeActivity.Surgery,
                StartDay = new DateTime(2023, 1, 1, 9, 0, 0),
                EndDay = new DateTime(2023, 1, 1, 17, 0, 0),
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