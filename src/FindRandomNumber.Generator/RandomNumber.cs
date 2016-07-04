using System;

namespace FindRandomNumber.Generator {
  public struct RandomNumber : IEquatable<RandomNumber> {
    public RandomNumber(short value) {
      Value = value;
    }

    public short Value { get; }

    public bool Equals(RandomNumber other) {
      return Value == other.Value;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      return obj is RandomNumber && Equals((RandomNumber)obj);
    }

    public override int GetHashCode() {
      return Value.GetHashCode();
    }

    public static bool operator ==(RandomNumber left, RandomNumber right) {
      return left.Equals(right);
    }

    public static bool operator !=(RandomNumber left, RandomNumber right) {
      return !left.Equals(right);
    }

    public static bool operator <=(RandomNumber left, RandomNumber right) {
      return left.Value <= right.Value;
    }

    public static bool operator >=(RandomNumber left, RandomNumber right) {
      return left.Value >= right.Value;
    }

    public static bool operator <(RandomNumber left, RandomNumber right) {
      return left.Value < right.Value;
    }

    public static bool operator >(RandomNumber left, RandomNumber right) {
      return left.Value > right.Value;
    }

    public static bool operator ==(RandomNumber left, short right) {
      return left.Value == right;
    }

    public static bool operator !=(RandomNumber left, short right) {
      return left.Value != right;
    }

    public static bool operator <=(RandomNumber left, short right) {
      return left.Value <= right;
    }

    public static bool operator >=(RandomNumber left, short right) {
      return left.Value >= right;
    }

    public static bool operator <(RandomNumber left, short right) {
      return left.Value < right;
    }

    public static bool operator >(RandomNumber left, short right) {
      return left.Value > right;
    }

    public static explicit operator RandomNumber(short value) {
      return new RandomNumber(value);
    }

    public static implicit operator short(RandomNumber randomNumber) {
      return randomNumber.Value;
    }

    public override string ToString() {
      return Value.ToString();
    }
  }
}
