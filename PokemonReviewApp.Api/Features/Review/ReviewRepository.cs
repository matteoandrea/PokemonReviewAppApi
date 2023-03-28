using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Features.Review;

public class ReviewRepository : RepositoryBase, IReviewRepository
{
	public ReviewRepository(DataContext context) : base(context) { }

	public async Task<ICollection<ReviewModel>> GetAllReviewsAsync()
	{
		try
		{
			return await _context.Reviews
				.ToListAsync()
				?? throw new InvalidOperationException("Review database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving reviews.", ex);
		}
	}

	public async Task<ReviewModel> GetReviewByIdAsync(Guid reviewId)
	{
		try
		{
			return await _context.Reviews
				.Where(x => x.Id.Equals(reviewId))
				.FirstOrDefaultAsync()
				?? throw new InvalidOperationException($"Review with ID {reviewId} not found.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving reviews.", ex);
		}
	}

	public async Task<ICollection<ReviewModel>> GetReviewsFromPokemonIdAsync(Guid pokemonId)
	{
		try
		{
			return await _context.Reviews
				.Where(x => x.Pokemon.Id.Equals(pokemonId))
				.ToListAsync()
				?? throw new InvalidOperationException("Review database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving reviews.", ex);
		}
	}
}
