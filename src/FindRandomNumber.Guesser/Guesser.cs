using System;

namespace FindRandomNumber.Guesser {
  public class Guesser : IGuesser {
    readonly short _minValue;
    readonly short _maxValue;

    public Guesser(short minValue, short maxValue) {
      if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue), "The maximum value is less than the minimum value.");
      _minValue = minValue;
      _maxValue = maxValue;
    }

    public GuessingSequence GuessRandomNumber() {
      throw new System.NotImplementedException();
    }
  }
}