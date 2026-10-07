using Vault.Domain;

namespace Vault.Api
{
    public sealed record PlayerClassResponse(
        ResourceLink Self,
        Dlc DLC,
        string Name,
        List<ResourceLink> Skills,
        List<ResourceLink> Players
        );
}
