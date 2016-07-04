using System;

namespace FindRandomNumber.Guesser {
  public class Guesser : IGuesser {
    readonly short _minValue;
    readonly short _maxValue;
    readonly short _valueToGuess;

    public Guesser(short minValue, short maxValue, short valueToGuess) {
      if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue), "The maximum value is less than the minimum value.");
      if (valueToGuess < minValue) throw new ArgumentOutOfRangeException(nameof(valueToGuess));
      if (valueToGuess > maxValue) throw new ArgumentOutOfRangeException(nameof(valueToGuess));
      _minValue = minValue;
      _maxValue = maxValue;
      _valueToGuess = valueToGuess;
    }

    public GuessingSequence GuessRandomNumber() {
      throw new System.NotImplementedException();
    }
  }
}