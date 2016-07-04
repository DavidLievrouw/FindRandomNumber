namespace FindRandomNumber.Guesser.AttemptCalculation {
  public interface IAttemptCalculator {
    Attempt CalculateNextAttempt(Guess? previousGuess);
  }
}