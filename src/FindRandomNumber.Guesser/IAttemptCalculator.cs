namespace FindRandomNumber.Guesser {
  public interface IAttemptCalculator {
    Attempt CalculateNextAttempt(Guess? previousGuess);
  }
}