using System;

namespace FindRandomNumber.Guesser {
  public class GuesserFactory : IGuesserFactory {
    readonly short _minValue;
    readonly short _maxValue;

    public GuesserFactory(short minValue, short maxValue) {
      if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue), "The maximum value is less than the minimum value.");
      _minValue = minValue;
      _maxValue = maxValue;
    }

    public IGuesser Create(short valueToGuess) {
      return new Guesser(_minValue, _maxValue, valueToGuess);
    }
  }
}