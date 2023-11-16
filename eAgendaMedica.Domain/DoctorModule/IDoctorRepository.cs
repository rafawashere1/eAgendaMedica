using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.DoctorModule
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        List<Doctor>? GetMany(List<Guid> selectedDoctors);
    }
}
