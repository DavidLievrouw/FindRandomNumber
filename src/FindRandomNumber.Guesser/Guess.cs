namespace FindRandomNumber.Guesser {
  public struct Guess {
    public Guess(Attempt attempt, RelationToTargetValue relationToTargetValue) {
      Attempt = attempt;
      RelationToTargetValue = relationToTargetValue;
    }

    public Attempt Attempt { get; }
    public RelationToTargetValue RelationToTargetValue { get; }
    public bool IsCorrectGuess => RelationToTargetValue == RelationToTargetValue.Correct;

    public override string ToString() {
      return $"Proposing number “{Attempt.Value}”... {(IsCorrectGuess ? "correct" : "incorrect")}.";
    }
  }
}