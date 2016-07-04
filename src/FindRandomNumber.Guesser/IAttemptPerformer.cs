using FindRandomNumber.Guessing.AttemptCalculation;

namespace FindRandomNumber.Guessing {
  public interface IAttemptPerformer {
    Guess PerformAttempt(Attempt attemptValue);
  }
}