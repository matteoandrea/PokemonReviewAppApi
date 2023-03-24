using PokemonReviewApp.Api.Features.Owner;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.PokemonOwner
{
	public class PokemonOwnerModel
	{
		public Guid PokemonId { get; set; }
		public Guid OwnerId { get; set; }
		public PokemonModel Pokemon { get; set; }
		public OwnerModel Owner { get; set; }
	}
}
