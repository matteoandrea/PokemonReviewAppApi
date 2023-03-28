using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Review;

namespace PokemonReviewApp.Api.Features.Reviewer;

public class ReviewerModel : ModelBase
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public ICollection<ReviewModel> Reviews { get; set; }
}
