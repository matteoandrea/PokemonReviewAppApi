using PokemonReviewApp.Api.Features.Category;
using PokemonReviewApp.Api.Features.Pokemons;

namespace PokemonReviewApp.Api.Features.PokemonCategory
{
    public class PokemonCategoryModel
    {
        public Guid PokemonId { get; set; }
        public Guid CategoryId { get; set; }

        public PokemonModel Pokemon { get; set; }
        public CategoryModel Category { get; set; }
    }
}
