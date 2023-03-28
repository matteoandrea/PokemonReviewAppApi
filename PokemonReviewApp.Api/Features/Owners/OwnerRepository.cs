using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Features.Owners;

public class OwnerRepository : RepositoryBase, IOwnerRepository
{
	public OwnerRepository(DataContext context) : base(context) { }

	public async Task<ICollection<OwnerModel>> GetAllOwnersAsync()
	{
		try
		{
			return await _context.Owners
				.ToListAsync()
				?? throw new InvalidOperationException($"Owner database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the list of Owners.", ex);
		}
	}

	public async Task<OwnerModel> GetOwnerByIdAsync(Guid ownerId)
	{
		try
		{
			return await _context.Owners
				.Where(x => x.Id.Equals(ownerId))
				.FirstOrDefaultAsync()
			?? throw new InvalidOperationException($"Owner with ID {ownerId} not found.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Owner.", ex);
		}
	}

	public async Task<ICollection<OwnerModel>> GetOwnerByPokemonIdAsync(Guid pokemonId)
	{
		try
		{
			return await _context.PokemonOwners
				.Where(x => x.PokemonId == pokemonId)
				.Select(x => x.Owner)
				.ToListAsync()
			?? throw new InvalidOperationException($"Owner with Pokemon ID {pokemonId} not found.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Owner.", ex);
		}
	}

	public async Task<ICollection<OwnerModel>> GetOwnersByCountryIdAsync(Guid countryId)
	{
		try
		{
			return await _context.Countries
				.Where(x => x.Id.Equals(countryId))
				.Select(x => x.Owners)
				.FirstOrDefaultAsync()
			?? throw new InvalidOperationException($"Owners with Country ID {countryId} not found.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Owner.", ex);
		}
	}
}
