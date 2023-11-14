namespace eAgendaMedica.Domain.Shared
{
    public interface IPersistenceContext
    {
        Task<bool> SaveAsync();
    }
}
