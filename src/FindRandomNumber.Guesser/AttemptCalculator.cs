using System;

namespace FindRandomNumber.Guesser {
  public class AttemptCalculator : IAttemptCalculator {
    readonly short _minValue;
    readonly short _maxValue;

    public AttemptCalculator(short minValue, short maxValue) {
      if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue), "The maximum value is less than the minimum value.");
      _minValue = minValue;
      _maxValue = maxValue;
    }

    public short CalculateNextAttempt(Guess? previousGuess) {
      throw new System.NotImplementedException();
    }
  }
}