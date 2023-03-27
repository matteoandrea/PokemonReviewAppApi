using AutoMapper;
using PokemonReviewApp.Api.Features.Category;
using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Helpler;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<PokemonModel, PokemonDto>();
		CreateMap<CategoryModel, CategoryDto>();
		CreateMap<CountryModel, CountryDto>();
	}
}
