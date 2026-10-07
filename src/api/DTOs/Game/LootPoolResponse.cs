using Vault.Api;

namespace Vault.Api
{
    public sealed record LootPoolResponse(
        ResourceLink Self,
        List<ResourceLink> Models);
}

