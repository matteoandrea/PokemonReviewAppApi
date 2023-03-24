using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Api.Features.Category;
using PokemonReviewApp.Api.Features.Country;
using PokemonReviewApp.Api.Features.Owner;
using PokemonReviewApp.Api.Features.Pokemons;
using PokemonReviewApp.Api.Features.PokemonCategory;
using PokemonReviewApp.Api.Features.PokemonOwner;
using PokemonReviewApp.Api.Features.Review;

namespace PokemonReviewApp.Api.Data;

public class DataContext : DbContext
{
	public DbSet<PokemonModel> Pokemons { get; set; }
	public DbSet<CountryModel> Countries { get; set; }
	public DbSet<CategoryModel> Categories { get; set; }
	public DbSet<OwnerModel> Owners { get; set; }
	public DbSet<PokemonOwnerModel> PokemonOwners { get; set; }
	public DbSet<PokemonCategoryModel> PokemonCategories { get; set; }
	public DbSet<ReviewModel> Reviews { get; set; }
	public DbSet<ReviewerModel> Reviewers { get; set; }

	public DataContext(DbContextOptions<DataContext> options)
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PokemonCategoryConfig());
		modelBuilder.ApplyConfiguration(new PokemonOwnerConfig());
	}

}
