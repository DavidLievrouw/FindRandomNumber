namespace FindRandomNumber.Guesser {
  public class GuessAttempter : IGuessAttempter {
    readonly short _valueToGuess;

    public GuessAttempter(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess AttemptGuess(Attempt attempt) {
      var relation = attempt.Value == _valueToGuess
        ? Relation.Correct
        : attempt.Value < _valueToGuess
          ? Relation.LowerThanTarget
          : Relation.GreaterThanTarget;

      return new Guess(attempt, relation);
    }
  }
}