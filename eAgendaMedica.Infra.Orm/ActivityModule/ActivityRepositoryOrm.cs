using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Infra.Orm.Shared;

namespace eAgendaMedica.Infra.Orm.ActivityModule
{
    public class ActivityRepositoryOrm : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepositoryOrm(eAgendaMedicaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
