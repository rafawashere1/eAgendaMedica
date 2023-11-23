using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.DoctorModule
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        bool Exist(Doctor doctor, bool isRemove = false);
        List<Doctor>? GetMany(List<Guid> selectedDoctors);
    }
}
