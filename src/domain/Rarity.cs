namespace Vault.Domain
{
    public sealed class Rarity(string name, string colorName, (byte, byte, byte) rgbColor)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = name;
        public string ColorName { get; init; } = colorName;
        public (byte Red, byte Green, byte Blue) Color { get; init; } = rgbColor;
        public byte Red => Color.Red;
        public byte Green => Color.Green;
        public byte Blue => Color.Blue;
    }
}
