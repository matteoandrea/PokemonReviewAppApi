using AutoMapper;
using PokemonReviewApp.Api.Features.Category;
using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.Owners;
using PokemonReviewApp.Api.Features.Pokemons;
using PokemonReviewApp.Api.Features.Review;
using PokemonReviewApp.Api.Features.Reviewer;

namespace PokemonReviewApp.Api.Helpler;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<PokemonModel, PokemonDto>();
		CreateMap<CategoryModel, CategoryDto>();
		CreateMap<CountryModel, CountryDto>();
		CreateMap<OwnerModel, OwnerDto>();
		CreateMap<ReviewModel, ReviewDto>();
		CreateMap<ReviewerModel, ReviewerDto>();
	}
}
