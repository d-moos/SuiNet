namespace Naami.SuiNet.Types;

public readonly struct SequenceNumber
{
    private readonly ulong _sequenceNumber;

    public SequenceNumber(ulong sequenceNumber)
    {
        _sequenceNumber = sequenceNumber;
    }

    public static implicit operator SequenceNumber(ulong sequenceNumber) => new(sequenceNumber);
    public static implicit operator ulong(SequenceNumber sequenceNumber) => sequenceNumber._sequenceNumber;
}