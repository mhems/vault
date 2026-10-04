using Vault.Domain;

namespace Vault.Application
{
    public sealed record PlayerClassDto(
        Guid Id,
        Dlc DLC,
        string Name,
        List<Guid> Skills,
        List<Guid> Players
        );
}
