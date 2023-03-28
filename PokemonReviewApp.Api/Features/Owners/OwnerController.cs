using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.Owners;

[ApiController]
[Route("[controller]")]
public class OwnerController : BaseController
{
	private readonly IOwnerRepository _repository;

	public OwnerController(IMapper mapper, IOwnerRepository repository) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OwnerDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<OwnerDto>>> GetAllOwners()
	{
		try
		{
			ICollection<OwnerModel> owners = await _repository.GetAllOwnersAsync();
			if (owners == null) return NotFound();
			ICollection<OwnerDto> dto = MapModelsToDtos<OwnerDto, OwnerModel>(owners);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("{ownerId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OwnerDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<OwnerDto>> GetOwnerByIdAsync(Guid ownerId)
	{
		try
		{
			OwnerModel owner = await _repository.GetOwnerByIdAsync(ownerId);
			if (owner == null) return NotFound();
			OwnerDto dto = MapModelToDtos<OwnerDto, OwnerModel>(owner);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("pokemons/{pokemonId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OwnerDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<OwnerDto>>> GetAllOwners(Guid pokemonId)
	{
		try
		{
			ICollection<OwnerModel> owners = await _repository.GetOwnerByPokemonIdAsync(pokemonId);
			if (owners == null) return NotFound();
			ICollection<OwnerDto> dto = MapModelsToDtos<OwnerDto, OwnerModel>(owners);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("countries/{countryId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OwnerDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<OwnerDto>>> GetOwnersByCountryIdAsync(Guid countryId)
	{
		try
		{
			ICollection<OwnerModel> owners = await _repository.GetOwnersByCountryIdAsync(countryId);
			if (owners == null) return NotFound();
			ICollection<OwnerDto> dto = MapModelsToDtos<OwnerDto, OwnerModel>(owners);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}
}
