namespace PokemonReviewApp.Api.Features.Pokemons;

public record PokemonDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
}
