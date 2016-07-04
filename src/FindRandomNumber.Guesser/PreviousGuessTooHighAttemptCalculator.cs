using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Guesser {
  public class PreviousGuessTooHighAttemptCalculator : IAttemptCalculator {
    readonly IMidPointCalculator _midPointCalculator;

    public PreviousGuessTooHighAttemptCalculator(IMidPointCalculator midPointCalculator) {
      if (midPointCalculator == null) throw new ArgumentNullException(nameof(midPointCalculator));
      _midPointCalculator = midPointCalculator;
    }

    public Attempt CalculateNextAttempt(Guess? previousGuess) {
      if (!previousGuess.HasValue) throw new ArgumentNullException(nameof(previousGuess));

      var previousAttempt = previousGuess.Value.Attempt;
      var newRange = new Range(previousAttempt.Range.Minimum, (short)(previousAttempt.Value - 1));
      return new Attempt(
        _midPointCalculator.CalculateMidPoint(newRange),
        newRange);
    }
  }
}