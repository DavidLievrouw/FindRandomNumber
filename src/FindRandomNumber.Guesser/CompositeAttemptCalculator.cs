using System;

namespace FindRandomNumber.Guesser {
  public class CompositeAttemptCalculator : IAttemptCalculator {
    readonly IAttemptCalculator _noPreviousGuessAttemptCalculator;
    readonly IAttemptCalculator _previousGuessTooLowAttemptCalculator;
    readonly IAttemptCalculator _previousGuessTooHighAttemptCalculator;

    public CompositeAttemptCalculator(
      IAttemptCalculator noPreviousGuessAttemptCalculator,
      IAttemptCalculator previousGuessTooLowAttemptCalculator,
      IAttemptCalculator previousGuessTooHighAttemptCalculator) {
      if (noPreviousGuessAttemptCalculator == null) throw new ArgumentNullException(nameof(noPreviousGuessAttemptCalculator));
      if (previousGuessTooLowAttemptCalculator == null) throw new ArgumentNullException(nameof(previousGuessTooLowAttemptCalculator));
      if (previousGuessTooHighAttemptCalculator == null) throw new ArgumentNullException(nameof(previousGuessTooHighAttemptCalculator));
      _noPreviousGuessAttemptCalculator = noPreviousGuessAttemptCalculator;
      _previousGuessTooLowAttemptCalculator = previousGuessTooLowAttemptCalculator;
      _previousGuessTooHighAttemptCalculator = previousGuessTooHighAttemptCalculator;
    }

    public Attempt CalculateNextAttempt(Guess? previousGuess) {
      if (!previousGuess.HasValue) return _noPreviousGuessAttemptCalculator.CalculateNextAttempt(null);

      return previousGuess.Value.RelationToCorrectAnswer == Relation.LowerThanTarget
        ? _previousGuessTooLowAttemptCalculator.CalculateNextAttempt(previousGuess)
        : _previousGuessTooHighAttemptCalculator.CalculateNextAttempt(previousGuess);
    }
  }
}