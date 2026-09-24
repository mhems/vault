using System;
using System.Collections.Generic;
using System.Text;

namespace Vault.Application
{
    public interface IPlayerQueries
    {
        Task<List<PlayerDto>> GetPlayersAsync(CancellationToken ct);

        Task<List<PlayerDto>> GetPlayersByClassAsync(string @class, CancellationToken ct);
    }
}
