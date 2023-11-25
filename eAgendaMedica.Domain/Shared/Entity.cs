using eAgendaMedica.Domain.AuthModule;

namespace eAgendaMedica.Domain.Shared
{
    public class Entity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
