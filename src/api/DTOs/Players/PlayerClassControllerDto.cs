using Vault.Domain;

namespace Vault.Api
{
    public sealed record PlayerClassControllerDto(
        ResourceLinkDto Self,
        Dlc DLC,
        string Name,
        List<ResourceLinkDto> Skills,
        List<ResourceLinkDto> Players
        );
}
