using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Features.Reviewer
{
	public class ReviewerRepository : RepositoryBase, IReviewerRepository
	{
		public ReviewerRepository(DataContext context) : base(context) { }

		public async Task<ICollection<ReviewerModel>> GetAllReviewersAsync()
		{
			try
			{
				return await _context.Reviewers
					.ToListAsync()
					?? throw new InvalidOperationException("Database empty.");
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the all the reviewers.", ex);
			}
		}

		public async Task<ICollection<ReviewerModel>> GetAllReviewersFromReviewsAsync(Guid reviewsId)
		{
			try
			{
				return await _context.Reviews
					.Where(x => x.Id.Equals(reviewsId))
					.Select(x => x.Reviewer)
					.ToListAsync()
					?? throw new InvalidOperationException("Database empty.");
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the all the reviewers.", ex);
			}
		}

		public async Task<ReviewerModel> GetReviewerByIdAsync(Guid reviewerId)
		{
			try
			{
				return await _context.Reviewers
							.Where(x => x.Id.Equals(reviewerId))
							.FirstOrDefaultAsync()
							?? throw new InvalidOperationException("Database empty.");
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the all the reviewers.", ex);
			}
		}
	}
}
