using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Pokemons;
using PokemonReviewApp.Api.Features.Reviewer;

namespace PokemonReviewApp.Api.Features.Review;

public class ReviewModel : ModelBase
{
	public string? Title { get; set; }
	public string? Text { get; set; }
	public int Rating { get; set; }
	public PokemonModel Pokemon { get; set; }
	public ReviewerModel Reviewer { get; set; }
}
