using System.ComponentModel.DataAnnotations;
using Vault.Api;

namespace Vault.Api
{
    public sealed record SkillResponse(
        ResourceLink Self,
        ResourceLink PlayerClass,
        string Name,
        [Range(1, 5)]
        int MaxPoints,
        string Tree,
        [Range(1, 6)]
        int TreeRow,
        [Range(1, 3)]
        int TreeColumn,
        string? Description
        );
}
