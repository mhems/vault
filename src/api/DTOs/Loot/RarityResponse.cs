namespace Vault.Api
{
    public sealed record RarityResponse(
        ResourceLink Self,
        string Name,
        string ColorName,
        string RgbaColorValue
        );
}
