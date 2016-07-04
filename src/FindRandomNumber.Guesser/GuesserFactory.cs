using System;

namespace FindRandomNumber.Guesser {
  public class GuesserFactory : IGuesserFactory {
    readonly IAttemptCalculator _attemptCalculator;

    public GuesserFactory(IAttemptCalculator attemptCalculator) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      _attemptCalculator = attemptCalculator;
    }

    public IGuesser Create(short valueToGuess) {
      return new Guesser(_attemptCalculator, new GuessAttempter(valueToGuess));
    }
  }
}