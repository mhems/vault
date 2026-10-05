using Microsoft.AspNetCore.Mvc;
using Vault.Application;

namespace Vault.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController(ICharacterApi api, LinkGenerator links) : VaultController(links)
    {
        #region queries
        internal const string GetCharactersRoute = "GetCharacters";
        internal const string GetCharacterRoute = "GetCharacter";
        #endregion

        private readonly ICharacterApi api = api;

        [HttpGet(Name = GetCharactersRoute)]
        public async Task<ActionResult<List<NonPlayableCharacterControllerDto>>> GetCharacters(CancellationToken ct)
        {
            var characters = await api.GetCharactersAsync(ct);
            var linkedCharacters = characters.Select(ConvertCharacter).ToList();
            return Ok(linkedCharacters);
        }

        [HttpGet("{id}", Name = GetCharacterRoute)]
        public async Task<ActionResult<NonPlayableCharacterControllerDto>> GetCharacter(Guid id, CancellationToken ct)
        {
            var character = await api.GetCharacterAsync(id, ct);
            var linkedCharacter = ConvertCharacter(character);
            return Ok(linkedCharacter);
        }
    }
}
