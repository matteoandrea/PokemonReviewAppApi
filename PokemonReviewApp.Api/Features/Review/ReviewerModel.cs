using PokemonReviewApp.Api.Core;

namespace PokemonReviewApp.Api.Features.Review;

public class ReviewerModel : ModelBase
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public ICollection<ReviewModel> Reviews { get; set; }
}
