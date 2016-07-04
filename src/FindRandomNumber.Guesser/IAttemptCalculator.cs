namespace FindRandomNumber.Guesser {
  public interface IAttemptCalculator {
    short CalculateNextAttempt(Guess? previousGuess);
  }
}