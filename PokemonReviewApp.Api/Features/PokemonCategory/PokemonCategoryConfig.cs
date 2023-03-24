using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace PokemonReviewApp.Api.Features.PokemonCategory;

public class PokemonCategoryConfig : IEntityTypeConfiguration<PokemonCategoryModel>
{
	public void Configure(EntityTypeBuilder<PokemonCategoryModel> builder)
	{
		builder.HasKey(x => new { x.PokemonId, x.CategoryId });

		builder
			.HasOne(x => x.Pokemon)
			.WithMany(x => x.PokemonCategories)
			.HasForeignKey(x => x.PokemonId);

		builder
			.HasOne(x => x.Category)
			.WithMany(x => x.PokemonCategories)
			.HasForeignKey(x => x.CategoryId);
	}
}
