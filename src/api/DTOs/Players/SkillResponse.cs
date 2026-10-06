using System.ComponentModel.DataAnnotations;
using Vault.Api;

namespace Vault.Application
{
    public sealed record SkillResponse(
        ResourceLinkDto Self,
        ResourceLinkDto PlayerClass,
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
