using eAgendaMedica.Domain.Shared;

namespace eAgendaMedica.Tests.Shared
{
    public class TestTenantProvider : ITenantProvider
    {
        public Guid UserId { get; set; }
        public TestTenantProvider(Guid userId)
        {
            UserId = userId;
        }
    }
}
