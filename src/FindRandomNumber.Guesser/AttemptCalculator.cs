using System;

namespace FindRandomNumber.Guesser {
  public class AttemptCalculator : IAttemptCalculator {
    readonly Range _range;

    public AttemptCalculator(Range range) {
      _range = range;
    }

    public Attempt CalculateNextAttempt(Guess? previousGuess) {
      // ToDo: Spike implementation, complete
      if (!previousGuess.HasValue) return new Attempt(MidPoint(_range.Minimum, _range.Maximum), new Range(_range.Minimum, _range.Maximum));
      return previousGuess.Value.RelationToCorrectAnswer == Relation.Smaller
        ? new Attempt(MidPoint(previousGuess.Value.Attempt.Value, previousGuess.Value.Attempt.Range.Maximum), new Range(previousGuess.Value.Attempt.Value, previousGuess.Value.Attempt.Range.Maximum))
        : new Attempt(MidPoint(previousGuess.Value.Attempt.Range.Minimum, previousGuess.Value.Attempt.Value), new Range(previousGuess.Value.Attempt.Range.Minimum, previousGuess.Value.Attempt.Value));
    }

    short MidPoint(short minValue, short maxValue) {
      return (short)Math.Round((minValue + maxValue)/2.0, 0, MidpointRounding.AwayFromZero);
    }
  }
}