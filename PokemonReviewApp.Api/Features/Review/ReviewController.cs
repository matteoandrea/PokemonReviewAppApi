using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Owners;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.Review;

[ApiController]
[Route("[controller]")]
public class ReviewController : BaseController
{
	private readonly IReviewRepository _repository;

	public ReviewController(IReviewRepository repository, IMapper mapper) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<ReviewDto>>> GetAllReviewsAsync()
	{
		try
		{
			ICollection<ReviewModel> reviews = await _repository.GetAllReviewsAsync();
			if (reviews == null) return NotFound();
			ICollection<ReviewDto> dto = MapModelsToDtos<ReviewDto, ReviewModel>(reviews);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}


	[HttpGet("{reviewId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ReviewModel>> GetReviewByIdAsync(Guid reviewId)
	{
		try
		{
			ReviewModel review = await _repository.GetReviewByIdAsync(reviewId);
			if (review == null) return NotFound();
			ReviewDto dto = MapModelToDtos<ReviewDto, ReviewModel>(review);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}


	[HttpGet("pokemons/{pokemonId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<ReviewModel>>> GetReviewsFromPokemonIdAsync(Guid pokemonId)
	{
		try
		{
			ICollection<ReviewModel> reviews = await _repository.GetReviewsFromPokemonIdAsync(pokemonId);
			if (reviews == null) return NotFound();
			ICollection<ReviewDto> dto = MapModelsToDtos<ReviewDto, ReviewModel>(reviews);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}
}
