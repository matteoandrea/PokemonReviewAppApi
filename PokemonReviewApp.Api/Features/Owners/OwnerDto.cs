using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.PokemonOwner;

namespace PokemonReviewApp.Api.Features.Owners;

public record OwnerDto
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Gym { get; set; }
	public CountryModel? Country { get; set; }
}
