namespace FindRandomNumber.Guesser {
  public interface IGuessAttempter {
    Guess AttemptGuess(Attempt attemptValue);
  }
}