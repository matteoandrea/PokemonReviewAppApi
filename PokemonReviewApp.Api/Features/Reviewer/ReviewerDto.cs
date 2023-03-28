namespace PokemonReviewApp.Api.Features.Reviewer;

public record ReviewerDto
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}
