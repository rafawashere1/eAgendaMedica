using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;

namespace eAgendaMedica.Infra.Orm.DoctorModule
{
    public class DoctorRepositoryOrm : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepositoryOrm(eAgendaMedicaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
