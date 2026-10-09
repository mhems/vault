using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;
using Vault.Domain;

namespace importer
{
    public static class CsvUtilities
    {
        private const string FilePath = "../../../../../data/db_data - {0}.csv";

        public static List<T> Parse<T>(string filename)
        {
            using var reader = new StreamReader(string.Format(FilePath, filename));
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using var csv = new CsvReader(reader, config);
            csv.Context.TypeConverterCache.AddConverter<bool>(new BooleanConverter());
            csv.Context.TypeConverterCache.AddConverter<Dlc>(new DlcConverter());
            csv.Context.TypeConverterOptionsCache.GetOptions<Manufacturer>().EnumIgnoreCase = true;
            csv.Context.TypeConverterOptionsCache.GetOptions<Gun>().EnumIgnoreCase = true;
            csv.Context.TypeConverterOptionsCache.GetOptions<Grenade>().EnumIgnoreCase = true;
            csv.Context.TypeConverterOptionsCache.GetOptions<Shield>().EnumIgnoreCase = true;
            csv.Context.TypeConverterOptionsCache.GetOptions<Relic?>().EnumIgnoreCase = true;

            return csv.GetRecords<T>().ToList();
        }

        public static List<RarityRow> ParseRarities() => Parse<RarityRow>("rarities");
        public static List<PlayerClassRow> ParseClasses() => Parse<PlayerClassRow>("classes");
        public static List<SkillRow> ParseSkills() => Parse<SkillRow>("skills");
        public static List<GunRow> ParseGuns() => Parse<GunRow>("guns");
        public static List<GrenadeRow> ParseGrenades() => Parse<GrenadeRow>("grenades");
        public static List<ShieldRow> ParseShields() => Parse<ShieldRow>("shields");
        public static List<ClassModRow> ParseClassMods() => Parse<ClassModRow>("classmods");
        public static List<RelicRow> ParseRelics() => Parse<RelicRow>("relics");
        public static List<MapRow> ParseMaps() => Parse<MapRow>("maps");
    }

    class BooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) ||
                text.Equals("false", StringComparison.InvariantCultureIgnoreCase) ||
                text.Equals("no", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            if (text.Equals("x", StringComparison.InvariantCultureIgnoreCase) ||
                text.Equals("true", StringComparison.InvariantCultureIgnoreCase) ||
                text.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            throw new ArgumentException($"unknown content '{text}'");
        }
    }

    class DlcConverter : DefaultTypeConverter
    {
        private static readonly string[] names = Enum.GetNames<Dlc>();
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("empty dlc");
            }
            Dlc? match = null;
            foreach (var name in names)
            {
                if (name.StartsWith(text, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (match != null)
                    {
                        throw new ArgumentException($"ambiguous match for {text}");
                    }
                    if (Enum.TryParse<Dlc>(name, out var dlc))
                    {
                        match = dlc;
                    }
                }
            }
            return match ?? throw new ArgumentException($"no match for '{text}'");
        }
    }

    public sealed record RarityRow(string Name, string Color, byte Red, byte Green, byte Blue);
    public sealed record PlayerClassRow(string Name, Dlc Dlc);
    public sealed record SkillRow(string Class, string Name, bool OnePointMax, string Tree, byte Tier, byte Column);
    public sealed record GunRow(string Name, Manufacturer Manufacturer, Gun SubCategory, Dlc Dlc, bool Unique, string Rarity,
        bool None, bool Incendiary, bool Shock, bool Corrosive, bool Explosive, bool Slag);
    public sealed record GrenadeRow(string Name, Manufacturer Manufacturer, Grenade SubCategory, Dlc Dlc, bool Unique, string Rarity,
        bool Sticky, bool None, bool Incendiary, bool Shock, bool Corrosive, bool Explosive, bool Slag);
    public sealed record ShieldRow(string Name, Manufacturer Manufacturer, Shield SubCategory, Dlc Dlc, bool Unique, string Rarity,
        bool None, bool Incendiary, bool Shock, bool Corrosive, bool Explosive, bool Slag);
    public sealed record ClassModRow(string Name, string Class, Manufacturer Manufacturer, Dlc Dlc, string Rarity);
    public sealed record RelicRow(string? Name, Relic? SubCategory, Manufacturer Manufacturer, Dlc Dlc, bool Unique, string Rarity);
    public sealed record MapRow(string Name, Dlc Dlc, byte NumFastTravels);
}
