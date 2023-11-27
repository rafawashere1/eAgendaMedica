using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace eAgendaMedica.Infra.Orm.Shared
{
    public class eAgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            var connectionString = configuration.GetConnectionString("PostgreSql");

            optionsBuilder.UseNpgsql(connectionString);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return new eAgendaMedicaDbContext(optionsBuilder.Options);
        }
    }
}
