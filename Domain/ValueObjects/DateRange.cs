namespace HackHub_DotNET.Domain.ValueObjects;

public sealed record DateRange : IValueObject
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (end < start)
            throw new ArgumentException("End must be on or after start.", nameof(end));

        Start = start;
        End = end;
    }

    public TimeSpan Duration => End - Start;

    public bool Contains(DateTime moment) => moment >= Start && moment <= End;

    public bool Overlaps(DateRange other) => Start < other.End && other.Start < End;
}
