using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor
            {
                CRM = "22347-SP",
                Name = "Dr. Exemplo3",
                LastActivity = DateTime.Now.AddDays(-1),
                CurrentActivity = new Domain.ActivityModule.Activity(),
                CurrentActivityId = Guid.NewGuid()
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

            dbContext.SaveChanges();
        }
    }
}