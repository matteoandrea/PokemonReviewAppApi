using PokemonReviewApp.Api.Data;
using PokemonReviewApp.Api.Features.Owner;

namespace PokemonReviewApp.Api.Features.Country;

public class CountryRepository : ICountryRepository
{
	private readonly DataContext _context;

	public CountryRepository(DataContext context)
		=> _context = context;

	public ICollection<CountryModel> GetCountries()
		=> _context.Countries.ToList();

	public CountryModel GetCountryById(Guid countryId)
	{
		throw new NotImplementedException();
	}

	public CountryModel GetCountryByOwner(Guid ownerId)
	{
		throw new NotImplementedException();
	}

	public ICollection<OwnerModel> GetOwnersByCountryId(Guid countryId)
	{
		throw new NotImplementedException();
	}
}
