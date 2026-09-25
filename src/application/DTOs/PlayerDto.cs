namespace Vault.Application
{
    public sealed record PlayerDto(
        Guid Id,
        string Class,
        string Name,
        byte Level,
        int? Experience,
        int? Money
        );
}
