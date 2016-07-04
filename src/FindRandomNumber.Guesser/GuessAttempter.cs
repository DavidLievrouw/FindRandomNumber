namespace FindRandomNumber.Guesser {
  public class GuessAttempter : IGuessAttempter {
    readonly short _valueToGuess;

    public GuessAttempter(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess AttemptGuess(short attemptValue) {
      throw new System.NotImplementedException();
    }
  }
}