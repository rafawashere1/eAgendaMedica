using Microsoft.AspNetCore.Identity;
using Taikandi;

namespace eAgendaMedica.Domain.AuthModule
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Id = SequentialGuid.NewGuid();
            EmailConfirmed = true;
        }

        public string Name { get; set; }
    }
}
