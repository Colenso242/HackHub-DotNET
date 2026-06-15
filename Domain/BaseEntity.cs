namespace HackHub_DotNET.Domain;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    // Guards a reference to another aggregate. Domain code can only assert the
    // id is present; existence of the referenced root is the caller's concern.
    protected static Guid RequireId(Guid id, string paramName)
        => id == Guid.Empty ? throw new ArgumentException($"{paramName} is required.", paramName) : id;
}
