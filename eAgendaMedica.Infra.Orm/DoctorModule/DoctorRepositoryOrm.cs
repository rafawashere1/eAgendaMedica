using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.Shared;

namespace eAgendaMedica.Infra.Orm.DoctorModule
{
    public class DoctorRepositoryOrm : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepositoryOrm(IPersistenceContext dbContext) : base(dbContext)
        {
        }
    }
}
