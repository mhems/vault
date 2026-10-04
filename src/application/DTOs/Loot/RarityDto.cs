namespace Vault.Application
{
    public sealed record RarityDto(
        Guid Id,
        string Name,
        string ColorName,
        string RgbaColorValue)
    {
        public RarityDto(Guid id,
            string name,
            string colorName,
            (byte red, byte blue, byte green) color)

            : this(id,
                  name,
                  colorName,
                  $"#{color.red:X2}{color.green:X2}{color.blue:X2}FF")
        {
        }
    }
}
