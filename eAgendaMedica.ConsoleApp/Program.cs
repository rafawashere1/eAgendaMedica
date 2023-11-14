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
        static async Task Main(string[] args)
        {
            Doctor doctor = new Doctor
            {
                CRM = "12347-SP",
                Name = "Dr. Exemplo2",
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

            var doctorRepository = new DoctorRepositoryOrm(dbContext);

            var doctorService = new DoctorAppService(doctorRepository, dbContext);

            doctorService.AddAsync(doctor);

            await Task.Delay(2000);

            dbContext.SaveChanges();
        }
    }
}