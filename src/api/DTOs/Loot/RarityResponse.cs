namespace Vault.Api
{
    public sealed record RarityResponse(
        ResourceLinkDto Self,
        string Name,
        string ColorName,
        string RgbaColorValue
        );
}
