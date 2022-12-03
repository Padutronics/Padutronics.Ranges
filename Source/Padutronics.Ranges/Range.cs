using Padutronics.Diagnostics.Debugging;
using Padutronics.Extensions.System;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Padutronics.Ranges;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Range<T> : IEquatable<Range<T>>
    where T : IComparable<T>
{
    public Range(T inclusiveLowerBound, T inclusiveUpperBound) :
        this(inclusiveLowerBound, inclusiveUpperBound, isLowerBoundIncluded: true, isUpperBoundIncluded: true)
    {
    }

    public Range(T lowerBound, T upperBound, bool isLowerBoundIncluded, bool isUpperBoundIncluded)
    {
        int relation = lowerBound.CompareTo(upperBound);

        if (isLowerBoundIncluded && isUpperBoundIncluded ? relation > 0 : relation >= 0)
        {
            throw new ArgumentException($"Range {(isLowerBoundIncluded ? '[' : '(')}{lowerBound}, {upperBound}{(isUpperBoundIncluded ? ']' : ')')} is invalid.");
        }

        IsLowerBoundIncluded = isLowerBoundIncluded;
        IsUpperBoundIncluded = isUpperBoundIncluded;
        LowerBound = lowerBound;
        UpperBound = upperBound;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"{(IsLowerBoundIncluded ? '[' : '(')}{LowerBound}, {UpperBound}{(IsUpperBoundIncluded ? ']' : ')')}";

    public bool IsLowerBoundIncluded { get; }

    public bool IsUpperBoundIncluded { get; }

    public T LowerBound { get; }

    public T UpperBound { get; }

    public bool Contains(T value)
    {
        return value.IsInRange(LowerBound, UpperBound, IsLowerBoundIncluded, IsUpperBoundIncluded);
    }
    public override bool Equals(object? obj)
    {
        return Equals(obj as Range<T>);
    }

    public bool Equals(Range<T>? other)
    {
        return other is not null &&
            IsLowerBoundIncluded == other.IsLowerBoundIncluded &&
            IsUpperBoundIncluded == other.IsUpperBoundIncluded &&
            EqualityComparer<T>.Default.Equals(LowerBound, other.LowerBound) &&
            EqualityComparer<T>.Default.Equals(UpperBound, other.UpperBound);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(IsLowerBoundIncluded, IsUpperBoundIncluded, LowerBound, UpperBound);
    }

    public static bool operator ==(Range<T>? left, Range<T>? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(Range<T>? left, Range<T>? right)
    {
        return !(left == right);
    }
}