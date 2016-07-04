using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public interface IAttemptPerformer {
    Guess PerformAttempt(Attempt attemptValue);
  }
}