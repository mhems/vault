namespace Vault.Application
{
    public sealed record SkillDto(
        Guid Id,
        Guid PlayerClassId,
        string Name,
        int MaxPoints,
        string Tree,
        int TreeRow,
        int TreeColumn,
        string? Description
        )
    {
        public SkillDto(
            Guid Id,
            Guid PlayerClassId,
            string Name,
            bool OnePointMax,
            string Tree,
            int TreeRow,
            int TreeColumn,
            string? Description
            )
            : this(
                  Id,
                  PlayerClassId,
                  Name,
                  OnePointMax ? 1 : 5,
                  Tree,
                  TreeRow,
                  TreeColumn,
                  Description)
        {

        }
    }
}
