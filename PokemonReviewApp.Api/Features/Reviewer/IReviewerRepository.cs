namespace PokemonReviewApp.Api.Features.Reviewer;

public interface IReviewerRepository
{
	Task<ICollection<ReviewerModel>> GetAllReviewersAsync();
	Task<ReviewerModel> GetReviewerByIdAsync(Guid reviewerId);
	Task<ICollection<ReviewerModel>> GetAllReviewersFromReviewsAsync(Guid reviewsId);
}
