namespace PokemonReviewApp.Api.Features.Country;

public interface ICountryRepository
{
	Task<ICollection<CountryModel>> GetCountriesAsync();
	Task<CountryModel> GetCountryByIdAsync(Guid countryId);
	Task<CountryModel> GetCountryByOwnerIdAsync(Guid ownerId);
}