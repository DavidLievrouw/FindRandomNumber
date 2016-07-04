using System;
using System.Collections.Generic;
using FindRandomNumber.Guessing.AttemptCalculation;

namespace FindRandomNumber.Guessing {
  public class Guesser : IGuesser {
    readonly IAttemptCalculator _attemptCalculator;
    readonly IAttemptPerformer _attemptPerformer;
    readonly int _maxAttempts;

    public Guesser(IAttemptCalculator attemptCalculator, IAttemptPerformer attemptPerformer, int maxAttempts) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      if (attemptPerformer == null) throw new ArgumentNullException(nameof(attemptPerformer));
      if (maxAttempts <= 0) throw new ArgumentOutOfRangeException(nameof(maxAttempts));
      _attemptCalculator = attemptCalculator;
      _attemptPerformer = attemptPerformer;
      _maxAttempts = maxAttempts;
    }

    public GuessingSequence GuessRandomNumber() {
      var attemptedGuesses = new List<Guess>();

      Guess? currentGuess = null;
      var attempt = 0;
      while (!currentGuess.HasValue || !currentGuess.Value.IsCorrectGuess) {
        // We implemented binary search, so this case should never occur.
        // But you never know who can mess up the implementation, so check anyway.
        attempt++;
        if (attempt > _maxAttempts) throw new InvalidOperationException("Too many attempts were performed without discovering the correct value.");

        var nextAttempt = _attemptCalculator.CalculateNextAttempt(currentGuess);
        currentGuess = _attemptPerformer.PerformAttempt(nextAttempt);
        attemptedGuesses.Add(currentGuess.Value);
      }

      return new GuessingSequence(attemptedGuesses);
    }
  }
}