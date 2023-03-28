namespace PokemonReviewApp.Api.Features.Review;

public interface IReviewRepository
{
	Task<ICollection<ReviewModel>> GetAllReviewsAsync();
	Task<ReviewModel> GetReviewByIdAsync(Guid reviewId);
	Task<ICollection<ReviewModel>> GetReviewsFromPokemonIdAsync(Guid pokemonId);
}
