namespace Vault.Domain
{
    public enum Dlc
    {
        BaseGame,
        CaptainScarlettAndHerPiratesBooty,
        MrTorguesCampaignOfCarnage,
        SirHammerlocksBigGameHunt,
        TinyTinasAssaultOnDragonKeep,
        CommanderLilithAndTheFightForSanctuary,
        CreatureSlaughterDome,
        Mechromancer,
        Psycho,
        CollectorsEdition,
        UltimateVaultHunterUpgrade,
        DigistructPeakChallenge,
        TKBahasBloodyHarvest,
        TheHorribleHungerOfTheRavenousWattleGobbler,
        HowMarcusSavedMercendaryDay,
        MadMoxxiAndTheWeddingDayMassacre,
        SirHammerlockVsTheSonOfCrawmerax,
    }

    public enum Manufacturer
    {
        Torgue,
        Vladof,
        Jakobs,
        Maliwan,
        Dahl,
        Bandit,
        Tediore,
        Hyperion,
        Anshin,
        Pangolin,
        Eridian,
    }

    public enum Element
    {
        None,
        Incendiary,
        Shock,
        Corrosive,
        Slag,
        Explosive,
    }

    public enum Equipment
    {
        Gun,
        Grenade,
        Shield,
        Relic,
        ClassMod
    }

    public enum Gun
    {
        AssaultRifle,
        Pistol,
        Shotgun,
        SubmachineGun,
        RocketLauncher,
        SniperRifle,
    }

    public enum Grenade
    {
        Standard,
        AreaOfEffect,
        BouncingBetty,
        MIRV,
        Singularity,
        Transfusion,
    }

    public enum GrenadeDelivery
    {
        Lobbed,
        Homing,
        Longbow,
        Rubberized
    }

    public enum Shield
    {
        Standard,
        Adaptive,
        Roid,
        Booster,
        Amplify,
        Spike,
        Nova,
        Turtle,
        Absorb
    }

    public enum Relic
    {
        Vitality,
        Allegiance,
        Stockpile,
        Protection,
        Aggression,
        Resistance,
        Tenacity,
        Elemental,
        Proficiency,
        Strength,
    }
}
