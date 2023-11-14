namespace eAgendaMedica.Domain.Shared
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<bool> AddAsync(T register);
        Task<List<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        void Remove(T register);
        void Update(T register);
    }
}
