using System;

namespace FindRandomNumber.Guesser {
  public struct Range {
    public Range(short minimum, short maximum) {
      if (minimum > maximum) throw new ArgumentOutOfRangeException(nameof(maximum), "Maximum is less than minimum.");
      Minimum = minimum;
      Maximum = maximum;
    }

    public short Minimum { get; }
    public short Maximum { get; }
  }
}