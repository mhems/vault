using Vault.Api;

namespace Vault.Application
{
    public sealed record SkillControllerDto(
        ResourceLinkDto Id,
        ResourceLinkDto PlayerClassId,
        string Name,
        int MaxPoints,
        string Tree,
        int TreeRow,
        int TreeColumn,
        string? Description
        );
}
