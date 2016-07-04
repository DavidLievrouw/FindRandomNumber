using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public interface IAttempter {
    Guess AttemptGuess(Attempt attemptValue);
  }
}