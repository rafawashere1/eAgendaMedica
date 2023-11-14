using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eAgendaMedica.Infra.Orm.Shared
{
    public class eAgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<eAgendaMedicaDbContext>
    {
        public eAgendaMedicaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eAgendaMedicaDbContext>();

            builder.UseSqlServer(@"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=eAgendaMedicaDb;Integrated Security=True");

            return new eAgendaMedicaDbContext(builder.Options);
        }
    }
}
