using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.PokemonOwner;

namespace PokemonReviewApp.Api.Features.Owners;

public class OwnerModel : ModelBase
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Gym { get; set; }
	public CountryModel? Country { get; set; }
	public ICollection<PokemonOwnerModel>? PokemonOwners { get; set; }
}
