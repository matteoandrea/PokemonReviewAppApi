using PokemonReviewApp.Api.Features.Owners;

namespace PokemonReviewApp.Api.Features.Pokemons;

public interface IPokemonRepository
{
	Task<ICollection<PokemonModel>> GetPokemonsAsync();
	Task<PokemonModel> GetPokemonByIdAsync(Guid id);
	Task<PokemonModel> GetPokemonByNameAsync(string name);
	Task<ICollection<PokemonModel>> GetPokemonByOwnerId(Guid ownerId);
	Task<decimal> GetPokemonRatingAsync(Guid id);
}
