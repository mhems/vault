using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class SkillApi(AppDbContext db) : ISkillApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<SkillDto>> GetSkillsAsync(CancellationToken ct)
        {
            return await db.Skills
              .Select(s => new SkillDto(
                  s.Id,
                  s.PlayerClassId,
                  s.Name,
                  s.OnePointMax,
                  s.Tree,
                  s.Tier,
                  s.Column,
                  s.Description))
              .ToListAsync(ct);
        }

        public async Task<List<SkillDto>> GetSkillsByPlayerClassAsync(string @class, CancellationToken ct)
        {
            return await db.Skills
                .Where(skill => skill.Class.Name == @class)
                .Select(s => new SkillDto(
                    s.Id,
                    s.PlayerClassId,
                    s.Name,
                    s.OnePointMax,
                    s.Tree,
                    s.Tier,
                    s.Column,
                    s.Description))
                .ToListAsync(ct);
        }

        public async Task<SkillDto> GetSkillAsync(Guid id, CancellationToken ct)
        {
            return await db.Skills
                .Where(s => s.Id == id)
                .Select(s => new SkillDto(
                    s.Id,
                    s.PlayerClassId,
                    s.Name,
                    s.OnePointMax,
                    s.Tree,
                    s.Tier,
                    s.Column,
                    s.Description))
                .SingleOrDefaultAsync(ct)
                ?? throw new KeyNotFoundException($"no such skill exists with ID {id}");
        }
    }
}
