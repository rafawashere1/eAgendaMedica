using AutoMapper;
using System.Security.Claims;

namespace eAgendaMedica.WebApi.Config.AutoMapperConfig
{
    public class UserResolver : IValueResolver<object, object, Guid>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserResolver(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid Resolve(object viewModel, object entity, Guid id, ResolutionContext context)
        {
            return Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
