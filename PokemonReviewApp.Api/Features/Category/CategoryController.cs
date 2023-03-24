using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.Category;

[ApiController]
[Route("[controller]")]
public class CategoryController : BaseController
{
	private readonly ICategoryRepository _repository;

	public CategoryController(ICategoryRepository repository, IMapper mapper) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<CategoryDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<CategoryDto>>> GetCategories()
	{
		try
		{
			ICollection<CategoryModel> categories = await _repository.GetCategoriesAsync();
			if (categories == null) return NotFound();
			ICollection<CategoryDto> dto = MapModelsToDtos<CategoryDto, CategoryModel>(categories);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
	{
		try
		{
			CategoryModel category = await _repository.GetCategoryByIdAsync(id);
			if (category == null) return NotFound();
			CategoryDto dto = MapModelToDtos<CategoryDto, CategoryModel>(category);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("pokemons/{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<PokemonDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<List<PokemonDto>>> GetPokemonsByCategoryId(Guid id)
	{
		try
		{
			ICollection<PokemonModel> pokemons = await _repository.GetPokemonsByCategoryIdAsync(id);
			if (pokemons == null) return NotFound();
			ICollection<PokemonDto> dto = MapModelsToDtos<PokemonDto, PokemonModel>(pokemons);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}
}