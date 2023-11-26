using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Domain.ActivityModule
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        List<Activity> GetAll();
    }
}
