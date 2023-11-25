using eAgendaMedica.Domain.Shared;
using System.Security.Claims;

namespace eAgendaMedica.WebApi.Config
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor contextAccessor;

        public TenantProvider(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var claimId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

                if (claimId == null)
                    return Guid.Empty;

                return Guid.Parse(claimId.Value);
            }
        }
    }
}
