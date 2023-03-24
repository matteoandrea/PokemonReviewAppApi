namespace PokemonReviewApp.Api.Core;

public abstract class ModelBase : IEquatable<ModelBase>
{
    public Guid Id { get; init; }

    public ModelBase()
        => Id = Guid.NewGuid();

    public bool Equals(ModelBase? other)
		=> Id == other?.Id;
}
