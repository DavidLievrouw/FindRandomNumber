namespace FindRandomNumber.Guesser {
  public interface IGuessAttempter {
    Guess AttemptGuess(short attemptValue);
  }
}