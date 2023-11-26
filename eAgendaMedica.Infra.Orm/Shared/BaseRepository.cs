using eAgendaMedica.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace eAgendaMedica.Infra.Orm.Shared
{

    public abstract class BaseRepository<T> where T : Entity
    {
        protected eAgendaMedicaDbContext DbContext { get; }
        protected DbSet<T> Registers { get; }

        public BaseRepository(IPersistenceContext ctx)
        {
            DbContext = ctx as eAgendaMedicaDbContext;
            Registers = DbContext.Set<T>();
        }

        public async Task<bool> AddAsync(T register)
        {
            await Registers.AddAsync(register);
            return true;
        }

        public void Update(T register)
        {
            Registers.Update(register);
        }

        public void Remove(T register)
        {
            Registers.Remove(register);
        }

        public virtual T GetById(Guid id)
        {
            return Registers.FirstOrDefault(x => x.Id == id);
        }

        public async virtual Task<T?> GetByIdAsync(Guid id)
        {
            return await Registers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async virtual Task<List<T>> GetAllAsync()
        {
            return await Registers.ToListAsync();
        }

        public virtual List<T> GetAll()
        {
            return Registers.ToList();
        }

        public abstract bool Exist(T obj, bool isRemove = false);
    }
}
