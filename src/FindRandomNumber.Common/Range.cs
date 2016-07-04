using System;

namespace FindRandomNumber.Common {
  public struct Range : IEquatable<Range> {
    public Range(short minimum, short maximum) {
      if (minimum > maximum) throw new ArgumentOutOfRangeException(nameof(maximum), "Maximum is less than minimum.");
      Minimum = minimum;
      Maximum = maximum;
    }

    public short Minimum { get; }
    public short Maximum { get; }

    public bool Equals(Range other) {
      return Minimum == other.Minimum && Maximum == other.Maximum;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      return obj is Range && Equals((Range)obj);
    }

    public override int GetHashCode() {
      unchecked {
        return (Minimum.GetHashCode()*397) ^ Maximum.GetHashCode();
      }
    }

    public static bool operator ==(Range left, Range right) {
      return left.Equals(right);
    }

    public static bool operator !=(Range left, Range right) {
      return !left.Equals(right);
    }
  }
}