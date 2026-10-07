using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Vault.Application;
using Vault.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IAccountApi, AccountApi>();
builder.Services.AddScoped<IPlayerApi, PlayerApi>();

builder.Services.AddScoped<IPlayerClassApi, PlayerClassApi>();
builder.Services.AddScoped<ISkillApi, SkillApi>();

builder.Services.AddScoped<IRarityApi, RarityApi>();
builder.Services.AddScoped<IRaritySetApi, RaritySetApi>();
builder.Services.AddScoped<IElementSetApi, ElementSetApi>();

builder.Services.AddScoped<IEquipmentModelApi, EquipmentModelApi>();

builder.Services.AddScoped<IEquipmentItemApi, EquipmentItemApi>();
builder.Services.AddScoped<IGunApi, GunApi>();
builder.Services.AddScoped<IGrenadeApi, GrenadeApi>();
builder.Services.AddScoped<IShieldApi, ShieldApi>();
builder.Services.AddScoped<IRelicApi, RelicApi>();
builder.Services.AddScoped<IClassModApi, ClassModApi>();

builder.Services.AddScoped<ILootPoolApi, LootPoolApi>();

builder.Services.AddScoped<IMissionApi, MissionApi>();

builder.Services.AddScoped<ILocationApi, LocationApi>();
builder.Services.AddScoped<IMapApi, MapApi>();
builder.Services.AddScoped<IAreaApi, AreaApi>();

builder.Services.AddScoped<ICharacterApi, CharacterApi>();
builder.Services.AddScoped<IEnemyApi, EnemyApi>();
builder.Services.AddScoped<IUniqueEnemyApi, UniqueEnemyApi>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;

    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter());
});

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict;

        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/api");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
