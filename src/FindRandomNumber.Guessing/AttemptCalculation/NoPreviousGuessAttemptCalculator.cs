using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  public class NoPreviousGuessAttemptCalculator : IAttemptCalculator {
    readonly IMidPointCalculator _midPointCalculator;
    readonly Range _fullRange;

    public NoPreviousGuessAttemptCalculator(IMidPointCalculator midPointCalculator, Range fullRange) {
      if (midPointCalculator == null) throw new ArgumentNullException(nameof(midPointCalculator));
      _midPointCalculator = midPointCalculator;
      _fullRange = fullRange;
    }

    public Attempt CalculateNextAttempt(Guess? previousGuess) {
      return new Attempt(
        _midPointCalculator.CalculateMidPoint(_fullRange),
        new Range(_fullRange.Minimum, _fullRange.Maximum));
    }
  }
}