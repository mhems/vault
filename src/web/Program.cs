using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Vault.Client;
using Vault.Web;
using Vault.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBaseUrl = builder.Configuration["ApiBaseUrl"]
    ?? throw new InvalidOperationException("ApiBaseUrl is missing.");

builder.Services.AddHttpClient("VaultApi", client =>
{
    client.Timeout = TimeSpan.FromSeconds(15);
});

builder.Services.AddScoped<IRequestAdapter>(sp =>
{
    var httpClient = sp
        .GetRequiredService<IHttpClientFactory>()
        .CreateClient("VaultApi");

    return new HttpClientRequestAdapter(
        new AnonymousAuthenticationProvider(),
        httpClient: httpClient)
    {
        BaseUrl = apiBaseUrl.TrimEnd('/')
    };
});

builder.Services.AddScoped<VaultApiClient>(sp =>
{
    var adapter = sp.GetRequiredService<IRequestAdapter>();
    return new VaultApiClient(adapter);
});

builder.Services.AddScoped<RaritySetService>();
builder.Services.AddScoped<ElementSetService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
