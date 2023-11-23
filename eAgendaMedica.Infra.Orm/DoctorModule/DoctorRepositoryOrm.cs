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
            if (doctorsIds == null)
            {
                return new List<Doctor>();
            }

            return Registers.Where(doctor => doctorsIds.Contains(doctor.Id)).ToList();
        }

        public override async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await Registers.Include(x => x.Activities).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Doctor>> GetAllAsync()
        {
            return await Registers.Include(x => x.Activities).ToListAsync();
        }

        public override bool Exist(Doctor doctor, bool isRemove = false)
        {
            if (isRemove)
                return Registers.Contains(doctor);

            return Registers.ToList().Any(a => a.CRM == doctor.CRM);
        }
    }
}
