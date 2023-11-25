namespace eAgendaMedica.Domain.Shared
{
    public interface ITenantProvider
    {
        Guid UserId { get; }
    }
}
