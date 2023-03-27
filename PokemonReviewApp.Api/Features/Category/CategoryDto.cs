namespace PokemonReviewApp.Api.Features.Category;

public record CategoryDto
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
}
