using Vault.Client;
using Vault.Client.Models;

namespace Vault.Web
{
    public abstract class CacheService<T>(VaultApiClient client)
    {
        private readonly Dictionary<Guid, T> cache = [];
        protected readonly VaultApiClient client = client;

        protected abstract dynamic Items { get; }

        public async Task<T?> GetAsync(Guid id)
        {
            if (cache.TryGetValue(id, out T? response))
            {
                return response;
            }

            response = await Items[id].GetAsync();

            if (response != null)
            {
                cache[id] = response;
            }

            return response;
        }
    }

    public class RaritySetService(VaultApiClient client) : CacheService<RaritySetResponse>(client)
    {
        protected override dynamic Items => client.Api.RaritySets;
    }

    public class ElementSetService(VaultApiClient client) : CacheService<ElementSetResponse>(client)
    {
        protected override dynamic Items => client.Api.ElementSets;
    }
}
