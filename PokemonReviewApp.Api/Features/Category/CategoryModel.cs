using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.PokemonCategory;

namespace PokemonReviewApp.Api.Features.Category;

public class CategoryModel : ModelBase
{
	public string? Name { get; set; }
	public ICollection<PokemonCategoryModel> PokemonCategories { get; set; }
}
