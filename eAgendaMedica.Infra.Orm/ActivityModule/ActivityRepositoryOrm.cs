using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.ActivityModule
{
    public class ActivityRepositoryOrm : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepositoryOrm(IPersistenceContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Activity?> GetByIdAsync(Guid id)
        {
            return await Registers.Include(x => x.Doctors).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
