using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.Shared;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.DoctorModule
{
    public class DoctorRepositoryOrm : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepositoryOrm(IPersistenceContext dbContext) : base(dbContext)
        {
        }

        public List<Doctor> GetMany(List<Guid> doctorsIds)
        {
            return Registers.Where(doctor => doctorsIds.Contains(doctor.Id)).ToList();
        }

        public override async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await Registers.Include(x => x.CurrentActivity).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
