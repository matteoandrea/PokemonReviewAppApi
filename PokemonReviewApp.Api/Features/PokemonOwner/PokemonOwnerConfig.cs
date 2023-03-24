using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PokemonReviewApp.Api.Features.PokemonOwner;

public class PokemonOwnerConfig : IEntityTypeConfiguration<PokemonOwnerModel>
{
	public void Configure(EntityTypeBuilder<PokemonOwnerModel> builder)
	{
		builder.HasKey(x => new { x.PokemonId, x.OwnerId });

		builder
			.HasOne(x => x.Pokemon)
			.WithMany(x => x.PokemonOwners)
			.HasForeignKey(x => x.PokemonId);

		builder
			.HasOne(x => x.Owner)
			.WithMany(x => x.PokemonOwners)
			.HasForeignKey(x => x.OwnerId);
	}
}
