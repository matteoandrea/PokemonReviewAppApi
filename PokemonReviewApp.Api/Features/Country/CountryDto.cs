namespace PokemonReviewApp.Api.Features.Country;

public record CountryDto
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
}
