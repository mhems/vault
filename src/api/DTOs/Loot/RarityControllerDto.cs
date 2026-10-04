namespace Vault.Api
{
    public sealed record RarityControllerDto(
        ResourceLinkDto Self,
        string Name,
        string ColorName,
        string RgbaColorValue
        );
}
