using Vault.Api;

namespace Vault.Application
{
    public sealed record LootPoolControllerDto(
        ResourceLinkDto Self,
        List<ResourceLinkDto> Models);
}

