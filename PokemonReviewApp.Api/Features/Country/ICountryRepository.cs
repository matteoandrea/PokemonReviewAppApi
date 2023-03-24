using PokemonReviewApp.Api.Features.Owner;

namespace PokemonReviewApp.Api.Features.Country;

public interface ICountryRepository
{
	ICollection<CountryModel> GetCountries();
	CountryModel GetCountryById(Guid countryId);
	CountryModel GetCountryByOwner(Guid ownerId);
	ICollection<OwnerModel> GetOwnersByCountryId(Guid countryId);
}