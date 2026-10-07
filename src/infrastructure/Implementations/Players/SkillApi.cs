using Microsoft.EntityFrameworkCore;
using Vault.Application;

namespace Vault.Infrastructure
{
    public class SkillApi(AppDbContext db) : ISkillApi
    {
        private readonly AppDbContext db = db;

        public async Task<List<SkillDto>> GetSkillsAsync(string? @class, CancellationToken ct)
        {
            var query = db.Skills.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(@class))
            {
                query = query.Where(s => s.Class.Name.Equals(@class, StringComparison.InvariantCultureIgnoreCase));
            }
            return await query
              .AsNoTracking()
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
                .AsNoTracking()
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
