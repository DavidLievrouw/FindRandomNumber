namespace FindRandomNumber.Guesser {
  public class GuessAttempter : IGuessAttempter {
    readonly short _valueToGuess;

    public GuessAttempter(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess AttemptGuess(short attemptValue) {
      var relation = attemptValue == _valueToGuess
        ? Relation.Correct
        : attemptValue < _valueToGuess
          ? Relation.Smaller
          : Relation.Larger;

      return new Guess(attemptValue, relation);
    }
  }
}