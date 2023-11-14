using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var doctor = new Doctor();
            doctor.Name = "Test";
            doctor.CRM = "Test";

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=eAgendaMedicaDb;Integrated Security=True");

            var dbContext = new eAgendaMedicaDbContext(optionsBuilder.Options);
            dbContext.Doctors.Add(doctor);
            dbContext.SaveChanges();
        }
    }
}