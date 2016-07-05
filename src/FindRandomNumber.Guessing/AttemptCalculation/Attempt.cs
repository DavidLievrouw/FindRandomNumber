using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  public struct Attempt : IComparable<short> {
    public Attempt(short value, Range range) {
      Value = value;
      Range = range;
    }

    public short Value { get; }
    public Range Range { get; }

    public int CompareTo(short targetValue) {
      return Value == targetValue
        ? 0 // Same as target value
        : Value < targetValue
          ? 1 // This instance precedes the target value
          : -1; // This instance follows the target value
    }
  }
}
