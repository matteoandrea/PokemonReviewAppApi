﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;

namespace PokemonReviewApp.Api.Features.Pokemons;

[ApiController]
[Route("[controller]")]
public class PokemonController : BaseController
{
	private readonly IPokemonRepository _repository;

	public PokemonController(IPokemonRepository repository, IMapper mapper) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PokemonDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<PokemonDto>>> GetPokemons()
	{
		try
		{
			ICollection<PokemonModel> pokemons = await _repository.GetPokemonsAsync();
			if (pokemons == null) return NotFound();
			ICollection<PokemonDto> dto = MapModelsToDtos<PokemonDto, PokemonModel>(pokemons);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}

	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PokemonDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<PokemonDto>> GetPokemonById(Guid id)
	{
		try
		{
			PokemonModel pokemon = await _repository.GetPokemonByIdAsync(id);
			if (pokemon == null) return NotFound();
			PokemonDto dtos = MapModelToDtos<PokemonDto, PokemonModel>(pokemon);

			return Ok(pokemon);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("{name}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PokemonDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<PokemonDto>> GetPokemonByName(string name)
	{
		try
		{
			PokemonModel pokemon = await _repository.GetPokemonByNameAsync(name);
			if (pokemon == null) return NotFound();
			PokemonDto dto = MapModelToDtos<PokemonDto, PokemonModel>(pokemon);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("{id}/reating")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
	public async Task<ActionResult<PokemonDto>> GetPokemonRating(Guid id)
	{
		try
		{
			decimal rating = await _repository.GetPokemonRatingAsync(id);
			return Ok(rating);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}
}
