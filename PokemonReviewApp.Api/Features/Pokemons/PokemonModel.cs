using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.PokemonCategory;
using PokemonReviewApp.Api.Features.PokemonOwner;
using PokemonReviewApp.Api.Features.Review;

namespace PokemonReviewApp.Api.Features.Pokemons;

public class PokemonModel : ModelBase
{
	public string Name { get; set; }
	public DateTime BirthDate { get; set; }
	public ICollection<ReviewModel> Reviews { get; set; }
	public ICollection<PokemonOwnerModel> PokemonOwners { get; set; }
	public ICollection<PokemonCategoryModel> PokemonCategories { get; set; }
}
