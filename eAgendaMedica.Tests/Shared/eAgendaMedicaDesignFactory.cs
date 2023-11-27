using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eAgendaMedica.Tests.Shared
{
    public class eAgendaMedicaDesignFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            Guid userId = Guid.Parse("A8BC593B-5945-417B-3C2A-08DBE8775234");

            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            var connectionString = configuration.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            return new eAgendaMedicaDbContext(optionsBuilder.Options, new TestTenantProvider(userId));
        }
    }
}
