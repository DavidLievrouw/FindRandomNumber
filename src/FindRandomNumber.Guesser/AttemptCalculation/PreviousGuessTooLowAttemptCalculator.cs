using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  public class PreviousGuessTooLowAttemptCalculator : IAttemptCalculator {
    readonly IMidPointCalculator _midPointCalculator;

    public PreviousGuessTooLowAttemptCalculator(IMidPointCalculator midPointCalculator) {
      if (midPointCalculator == null) throw new ArgumentNullException(nameof(midPointCalculator));
      _midPointCalculator = midPointCalculator;
    }

    public Attempt CalculateNextAttempt(Guess? previousGuess) {
      if (!previousGuess.HasValue) throw new ArgumentNullException(nameof(previousGuess));

      var previousAttempt = previousGuess.Value.Attempt;
      var newRange = new Range((short)(previousAttempt.Value + 1), previousAttempt.Range.Maximum);
      return new Attempt(
        _midPointCalculator.CalculateMidPoint(newRange),
        newRange);
    }
  }
}