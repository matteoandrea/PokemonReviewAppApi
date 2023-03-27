using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;

namespace PokemonReviewApp.Api.Features.Country;

public class CountryRepository : RepositoryBase, ICountryRepository
{
	public CountryRepository(DataContext context) : base(context) { }

	public async Task<ICollection<CountryModel>> GetCountriesAsync()
	{
		try
		{
			return await _context.Countries
				.ToListAsync()
				?? throw new InvalidOperationException($"Country database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the list of Countries.", ex);
		}
	}

	public async Task<CountryModel> GetCountryByIdAsync(Guid countryId)
	{
		try
		{
			return await _context.Countries
				.Where(x => x.Id.Equals(countryId))
				.FirstOrDefaultAsync()
				?? throw new InvalidOperationException($"Country with ID {countryId} not found.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the country by ID.", ex);
		}
	}

	public async Task<CountryModel> GetCountryByOwnerIdAsync(Guid ownerId)
	{
		try
		{
			return await _context.Owners
				.Where(x => x.Id.Equals(ownerId))
				.Select(x => x.Country)
				.FirstOrDefaultAsync()
				?? throw new InvalidOperationException($"Country database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the list of Countries.", ex);
		}
	}

	//	 TODO: Transfer this code to owner controller
	/*
	public async Task<ICollection<OwnerModel>> GetOwnersByCountryIdAsync(Guid countryId)
	{
		try
		{
			return await _context.Owners
				.Where(x => x.Id.Equals(countryId))
				.ToListAsync()
				?? throw new InvalidOperationException($"Country database is empty.");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the list of Countries.", ex);
		}
	}
	*/
}
