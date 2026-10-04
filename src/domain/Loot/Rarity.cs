namespace Vault.Domain
{
    public sealed class Rarity(string name, string colorName, (byte, byte, byte) rgbColor)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = name;
        public string ColorName { get; init; } = colorName;
        public (byte Red, byte Green, byte Blue) Color => (Red, Green, Blue);
        public byte Red { get; set; } = rgbColor.Item1;
        public byte Green { get; set; } = rgbColor.Item2;
        public byte Blue { get; set; } = rgbColor.Item3;

        private Rarity() : this(string.Empty, string.Empty, (255, 255, 255)) { }
    }
}
