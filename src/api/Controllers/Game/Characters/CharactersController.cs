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
        [ProducesResponseType(typeof(List<NonPlayableCharacterResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<NonPlayableCharacterResponse>>> GetCharacters(CancellationToken ct)
        {
            var characters = await api.GetCharactersAsync(ct);
            var linkedCharacters = characters.Select(ConvertCharacter).ToList();
            return Ok(linkedCharacters);
        }

        [HttpGet("{id}", Name = GetCharacterRoute)]
        [ProducesResponseType(typeof(NonPlayableCharacterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NonPlayableCharacterResponse>> GetCharacter(Guid id, CancellationToken ct)
        {
            try
            {
                var character = await api.GetCharacterAsync(id, ct);
                var linkedCharacter = ConvertCharacter(character);
                return Ok(linkedCharacter);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
