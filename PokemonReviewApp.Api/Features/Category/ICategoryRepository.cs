using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.Category;

public interface ICategoryRepository
{
	Task<ICollection<CategoryModel>> GetCategoriesAsync();
	Task<CategoryModel> GetCategoryByIdAsync(Guid id);
	Task<ICollection<PokemonModel>> GetPokemonsByCategoryIdAsync(Guid id);
}
