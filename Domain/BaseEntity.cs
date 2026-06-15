namespace HackHub_DotNET.Domain;

public abstract class BaseEntity
{
    //TODO fix, hashcode ignores id,equals doesn't
    public long Id { get; protected set; }
    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity other || GetType() != other.GetType())
            return false;

        // Transient entities (not yet persisted) are only equal by reference.
        if (Id == 0 || other.Id == 0)
            return ReferenceEquals(this, other);

        return Id == other.Id;
    }

    public override int GetHashCode() => GetType().GetHashCode();

    public static bool operator ==(BaseEntity? left, BaseEntity? right) => Equals(left, right);

    public static bool operator !=(BaseEntity? left, BaseEntity? right) => !Equals(left, right);
}