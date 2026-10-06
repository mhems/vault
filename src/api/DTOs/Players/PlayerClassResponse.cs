using Vault.Domain;

namespace Vault.Api
{
    public sealed record PlayerClassResponse(
        ResourceLinkDto Self,
        Dlc DLC,
        string Name,
        List<ResourceLinkDto> Skills,
        List<ResourceLinkDto> Players
        );
}
