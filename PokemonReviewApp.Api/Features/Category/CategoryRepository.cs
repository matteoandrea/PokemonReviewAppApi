using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Core;
using PokemonReviewApp.Api.Data;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.Category;

public class CategoryRepository : RepositoryBase, ICategoryRepository
{
	public CategoryRepository(DataContext context) : base(context) { }

	public async Task<CategoryModel> GetCategoryByIdAsync(Guid id)
	{
		try
		{
			return await _context.Categories
				.FirstOrDefaultAsync(x => x.Id.Equals(id))
				?? throw new InvalidOperationException($"Category with ID {id} not found");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Category by ID.", ex);
		}
	}

	public async Task<ICollection<PokemonModel>> GetPokemonsByCategoryIdAsync(Guid id)
	{
		try
		{
			return await _context.PokemonCategories
				.Where(x => x.CategoryId.Equals(id))
				.Select(x => x.Pokemon)
				.ToListAsync()
				?? throw new InvalidOperationException($"Category with ID {id} not found");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Category by ID.", ex);
		}
	}

	public async Task<ICollection<CategoryModel>> GetCategoriesAsync()
	{
		try
		{
			return await _context.Categories
				.ToListAsync()
				?? throw new InvalidOperationException($"Categories not found");
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while retrieving the Categories", ex);
		}
	}
}
