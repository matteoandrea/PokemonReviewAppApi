using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Core
{
	public class RepositoryBase
	{
		private protected readonly DataContext _context;

		public RepositoryBase(DataContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
	}
}
