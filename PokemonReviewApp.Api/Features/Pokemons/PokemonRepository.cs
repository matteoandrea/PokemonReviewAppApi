using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Features.Pokemons
{
	public class PokemonRepository : RepositoryBase, IPokemonRepository
	{
		public PokemonRepository(DataContext context) : base(context) { }

		public async Task<PokemonModel> GetPokemonByNameAsync(string name)
		{
			try
			{
				return await _context.Pokemons
					.FirstOrDefaultAsync(x => x.Name == name)
					?? throw new InvalidOperationException($"Pokemon with ID {name} not found.");

			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the Pokemon by name.", ex);
			}
		}

		public async Task<PokemonModel> GetPokemonByIdAsync(Guid id)
		{
			try
			{
				return await _context.Pokemons
					.FirstOrDefaultAsync(x => x.Id.Equals(id))
					?? throw new InvalidOperationException($"Pokemon with ID {id} not found.");
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the Pokemon by ID.", ex);
			}
		}

		public async Task<decimal> GetPokemonRatingAsync(Guid id)
		{
			try
			{
				PokemonModel pokemon = await _context.Pokemons
					.FirstOrDefaultAsync(x => x.Id.Equals(id))
					?? throw new InvalidOperationException($"Pokemon with ID {id} not found.");

				if (pokemon.Reviews.IsNullOrEmpty()) return 0;

				return (decimal)pokemon.Reviews.Average(r => r.Rating);
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the Pokemon rating.", ex);
			}
		}

		public async Task<ICollection<PokemonModel>> GetPokemonsAsync()
		{
			try
			{
				return await _context.Pokemons
					.ToListAsync()
					?? throw new InvalidOperationException($"Pokemon database is empty.");

			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving the list of Pokemons.", ex);
			}
		}
	}
}
