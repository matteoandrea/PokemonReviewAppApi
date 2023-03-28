using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Owners;

namespace PokemonReviewApp.Api.Features.Country;

public class CountryModel : ModelBase
{
	public string? Name { get; set; }
	public ICollection<OwnerModel>? Owners { get; set; }
}
