using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PokemonReviewApp.Api.Core
{
	public class BaseController : ControllerBase
	{
		private protected readonly IMapper _mapper;

		public BaseController(IMapper mapper)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		protected List<D> MapModelsToDtos<D, M>(ICollection<M> models)
			where D : class
			where M : class
		{
			try
			{
				return _mapper.Map<List<D>>(models);
			}
			catch (AutoMapperMappingException ex)
			{
				throw new AutoMapperMappingException("An error occurred while mapping.", ex.InnerException);
			}
		}
		protected D MapModelToDtos<D, M>(M model)
			where D : class
			where M : class
		{
			try
			{
				return _mapper.Map<D>(model);
			}
			catch (AutoMapperMappingException ex)
			{
				throw new AutoMapperMappingException("An error occurred while mapping.", ex.InnerException);
			}
		}
	}
}
