using System.ComponentModel.DataAnnotations;

namespace Vault.Application
{
    public sealed record SkillDto(
        Guid Id,
        Guid PlayerClassId,
        string Name,
        [Range(1, 5)]
        int MaxPoints,
        string Tree,
        [Range(1, 6)]
        int TreeRow,
        [Range(1, 3)]
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
