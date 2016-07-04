using System;
using System.Collections.Generic;
using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public class Guesser : IGuesser {
    readonly IAttemptCalculator _attemptCalculator;
    readonly IAttemptPerformer _attemptPerformer;

    public Guesser(IAttemptCalculator attemptCalculator, IAttemptPerformer attemptPerformer) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      if (attemptPerformer == null) throw new ArgumentNullException(nameof(attemptPerformer));
      _attemptCalculator = attemptCalculator;
      _attemptPerformer = attemptPerformer;
    }

    public GuessingSequence GuessRandomNumber() {
      // ToDo: No more than 15 guesses
      var attemptedGuesses = new List<Guess>();

      Guess? currentGuess = null;
      while (!currentGuess.HasValue || !currentGuess.Value.IsCorrectGuess) {
        var nextAttempt = _attemptCalculator.CalculateNextAttempt(currentGuess);
        currentGuess = _attemptPerformer.PerformAttempt(nextAttempt);
        attemptedGuesses.Add(currentGuess.Value);
      }

      return new GuessingSequence(attemptedGuesses);
    }
  }
}