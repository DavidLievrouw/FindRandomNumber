using System;
using System.Collections.Generic;

namespace FindRandomNumber.Guesser {
  public class Guesser : IGuesser {
    readonly IAttemptCalculator _attemptCalculator;
    readonly IGuessAttempter _guessAttempter;

    public Guesser(IAttemptCalculator attemptCalculator, IGuessAttempter guessAttempter) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      if (guessAttempter == null) throw new ArgumentNullException(nameof(guessAttempter));
      _attemptCalculator = attemptCalculator;
      _guessAttempter = guessAttempter;
    }

    public GuessingSequence GuessRandomNumber() {
      // ToDo: No more than 15 guesses
      var attemptedGuesses = new List<Guess>();

      Guess? currentGuess = null;
      while (!currentGuess.HasValue || !currentGuess.Value.IsCorrectGuess) {
        var nextAttempt = _attemptCalculator.CalculateNextAttempt(currentGuess);
        currentGuess = _guessAttempter.AttemptGuess(nextAttempt);
        attemptedGuesses.Add(currentGuess.Value);
      }

      return new GuessingSequence(attemptedGuesses);
    }
  }
}