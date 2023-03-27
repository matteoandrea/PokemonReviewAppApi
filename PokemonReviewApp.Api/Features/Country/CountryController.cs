using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;

namespace PokemonReviewApp.Api.Features.Country;

[ApiController]
[Route("[controller]")]
public class CountryController : BaseController
{
	private readonly ICountryRepository _repository;

	public CountryController(ICountryRepository repository, IMapper mapper) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<CountryDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<CountryDto>>> GetCountriesAsync()
	{
		try
		{
			ICollection<CountryModel> countries = await _repository.GetCountriesAsync();
			if (countries == null) return NotFound();
			ICollection<CountryDto> dtos = MapModelsToDtos<CountryDto, CountryModel>(countries);

			return Ok(dtos);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("/{countryId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CountryDto>> GetCountryByIdAsync(Guid countryId)
	{
		try
		{
			CountryModel country = await _repository.GetCountryByIdAsync(countryId);
			if (country == null) return NotFound();
			CountryDto dtos = MapModelToDtos<CountryDto, CountryModel>(country);

			return Ok(dtos);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("owners/{ownerId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountryDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<CountryModel>> GetCountryByOwnerIdAsync(Guid ownerId)
	{
		try
		{
			CountryModel country = await _repository.GetCountryByOwnerIdAsync(ownerId);
			if (country == null) return NotFound();
			CountryDto dtos = MapModelToDtos<CountryDto, CountryModel>(country);

			return Ok(dtos);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	//	 TODO: Transfer this code to owner controller
	/*
	[HttpGet()]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OwnerModel>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<OwnerModel>>> GetOwnersByCountryIdAsync(Guid countryId)
	{
		try
		{
			ICollection<OwnerModel> owners = await _repository.GetOwnersByCountryIdAsync(countryId);
			if (owners == null) return NotFound();
			CountryDto dtos = MapModelToDtos<OwnerDto, OwnerModel>(owners);

			return Ok(dtos);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}

	}
	*/
}
