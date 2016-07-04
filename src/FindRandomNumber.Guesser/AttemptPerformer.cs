using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public class AttemptPerformer : IAttemptPerformer {
    readonly short _valueToGuess;

    public AttemptPerformer(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess PerformAttempt(Attempt attempt) {
      var relation = attempt.Value == _valueToGuess
        ? RelationToTargetValue.Correct
        : attempt.Value < _valueToGuess
          ? RelationToTargetValue.LessThanTargetValue
          : RelationToTargetValue.GreaterThanTargetValue;

      return new Guess(attempt, relation);
    }
  }
}