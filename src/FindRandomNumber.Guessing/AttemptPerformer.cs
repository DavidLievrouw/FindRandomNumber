using FindRandomNumber.Guessing.AttemptCalculation;

namespace FindRandomNumber.Guessing {
  public class AttemptPerformer : IAttemptPerformer {
    readonly short _valueToGuess;

    public AttemptPerformer(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess PerformAttempt(Attempt attempt) {
      var comparisonResult = attempt.CompareTo(_valueToGuess);

      var relation = comparisonResult == 0
        ? RelationToTargetValue.Correct
        : comparisonResult > 0
          ? RelationToTargetValue.LessThanTargetValue
          : RelationToTargetValue.GreaterThanTargetValue;

      return new Guess(attempt, relation);
    }
  }
}