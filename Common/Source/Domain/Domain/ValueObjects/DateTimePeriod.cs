namespace Common.Domain.ValueObjects;

[ValueObject]
public record DateTimePeriod
{
    public DateTimePeriod(DateTime start, DateTime end)
    {
        if (start >= end)
            throw new ArgumentOutOfRangeException($"Start ({start}) must be earlier than End ({end})");

        Start = start;
        End = end;
    }

    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
}