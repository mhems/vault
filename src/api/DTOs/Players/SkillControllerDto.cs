using Vault.Api;

namespace Vault.Application
{
    public sealed record SkillControllerDto(
        ResourceLinkDto Self,
        ResourceLinkDto PlayerClass,
        string Name,
        int MaxPoints,
        string Tree,
        int TreeRow,
        int TreeColumn,
        string? Description
        );
}
