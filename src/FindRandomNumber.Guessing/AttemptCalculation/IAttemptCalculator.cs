namespace FindRandomNumber.Guessing.AttemptCalculation {
  public interface IAttemptCalculator {
    Attempt CalculateNextAttempt(Guess? previousGuess);
  }
}