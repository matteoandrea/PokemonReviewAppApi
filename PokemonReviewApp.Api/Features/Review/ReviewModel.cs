using PokemonReviewApp.Api.Core;

namespace PokemonReviewApp.Api.Features.Review;

public class ReviewModel : ModelBase
{
	public string Title { get; set; }
	public string Text { get; set; }
	public int Rating { get; set; }
	public ReviewerModel Reviewer { get; set; }
}
