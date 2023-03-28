using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Api.Core;

namespace PokemonReviewApp.Api.Features.Reviewer;

[ApiController]
[Route("[controller]")]
public class ReviewerController : BaseController
{
	private readonly IReviewerRepository _repository;

	public ReviewerController(IMapper mapper, IReviewerRepository repository) : base(mapper)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewerDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<ReviewerDto>>> GetAllReviewersAsync()
	{
		try
		{
			ICollection<ReviewerModel> reviewers = await _repository.GetAllReviewersAsync();
			if (reviewers == null) return NotFound();
			ICollection<ReviewerDto> dto = MapModelsToDtos<ReviewerDto, ReviewerModel>(reviewers);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("reviews/{reviewsId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ReviewerDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ICollection<ReviewerDto>>> GetAllReviewersFromReviewsAsync(Guid reviewsId)
	{
		try
		{
			ICollection<ReviewerModel> reviewers = await _repository.GetAllReviewersFromReviewsAsync(reviewsId);
			if (reviewers == null) return NotFound();
			ICollection<ReviewerDto> dto = MapModelsToDtos<ReviewerDto, ReviewerModel>(reviewers);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}

	[HttpGet("{reviewerId:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReviewerDto))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<ReviewerDto>> GetReviewerByIdAsync(Guid reviewerId)
	{
		try
		{
			ReviewerModel reviewers = await _repository.GetReviewerByIdAsync(reviewerId);
			if (reviewers == null) return NotFound();
			ReviewerDto dto = MapModelToDtos<ReviewerDto, ReviewerModel>(reviewers);

			return Ok(dto);
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred.", ex);
		}
	}
}
