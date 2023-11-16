using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.Shared;

namespace eAgendaMedica.Infra.Orm.ActivityModule
{
    public class ActivityRepositoryOrm : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepositoryOrm(IPersistenceContext dbContext) : base(dbContext)
        {

        }
    }
}
