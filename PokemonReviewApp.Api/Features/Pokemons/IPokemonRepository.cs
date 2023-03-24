namespace PokemonReviewApp.Api.Features.Pokemons;

public interface IPokemonRepository
{
	Task<ICollection<PokemonModel>> GetPokemonsAsync();
	Task<PokemonModel> GetPokemonByIdAsync(Guid id);
	Task<PokemonModel> GetPokemonByNameAsync(string name);
	Task<decimal> GetPokemonRatingAsync(Guid id);
}
