using System;
using FindRandomNumber.Guessing.AttemptCalculation;

namespace FindRandomNumber.Guessing {
  public class GuesserFactory : IGuesserFactory {
    readonly IAttemptCalculator _attemptCalculator;
    readonly int _maxAttempts;

    public GuesserFactory(IAttemptCalculator attemptCalculator, int maxAttempts) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      if (maxAttempts <= 0) throw new ArgumentOutOfRangeException(nameof(maxAttempts));
      _attemptCalculator = attemptCalculator;
      _maxAttempts = maxAttempts;
    }

    public IGuesser Create(short valueToGuess) {
      return new Guesser(_attemptCalculator, new AttemptPerformer(valueToGuess), _maxAttempts);
    }
  }
}