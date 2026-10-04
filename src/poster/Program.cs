using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Vault.Client;
using Vault.Client.Models;

var authProvider = new AnonymousAuthenticationProvider();

var adapter = new HttpClientRequestAdapter(authProvider)
{
    BaseUrl = "https://localhost:7069"
};

var client = new VaultApiClient(adapter);

var dto = new AddPlayerDto
{
    AccountId = Guid.Parse("3e46af6c-fb16-4847-9069-c03b665f4997"),
    PlayerClassId = Guid.Parse("6e307e8c-a4cb-4f3a-abc1-8872cbb2b4c3"),
    Name = "ms. sir",
};

Guid? playerId = await client.Api.Players.Add.PostAsync(dto);
Console.WriteLine($"<{playerId}>");