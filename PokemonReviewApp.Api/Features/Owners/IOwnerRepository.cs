namespace PokemonReviewApp.Api.Features.Owners;

public interface IOwnerRepository
{
	Task<ICollection<OwnerModel>> GetAllOwnersAsync();
	Task<OwnerModel> GetOwnerByIdAsync(Guid ownerId);
	Task<ICollection<OwnerModel>> GetOwnerByPokemonIdAsync(Guid pokemonId);
	Task<ICollection<OwnerModel>> GetOwnersByCountryIdAsync(Guid countryId);
}
