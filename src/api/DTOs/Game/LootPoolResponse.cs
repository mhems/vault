using Vault.Api;

namespace Vault.Application
{
    public sealed record LootPoolResponse(
        ResourceLinkDto Self,
        List<ResourceLinkDto> Models);
}

