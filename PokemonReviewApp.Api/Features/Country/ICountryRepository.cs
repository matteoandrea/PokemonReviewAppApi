namespace PokemonReviewApp.Api.Features.Country;

public interface ICountryRepository
{
	Task<ICollection<CountryModel>> GetCountriesAsync();
	Task<CountryModel> GetCountryByIdAsync(Guid countryId);
	Task<CountryModel> GetCountryByOwnerIdAsync(Guid ownerId);

	//	 TODO: Transfer this code to owner controller
	// Task<ICollection<OwnerModel>> GetOwnersByCountryIdAsync(Guid countryId);
}