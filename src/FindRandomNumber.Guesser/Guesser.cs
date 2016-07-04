using System;
using System.Collections.Generic;
using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public class Guesser : IGuesser {
    readonly IAttemptCalculator _attemptCalculator;
    readonly IAttempter _attempter;

    public Guesser(IAttemptCalculator attemptCalculator, IAttempter attempter) {
      if (attemptCalculator == null) throw new ArgumentNullException(nameof(attemptCalculator));
      if (attempter == null) throw new ArgumentNullException(nameof(attempter));
      _attemptCalculator = attemptCalculator;
      _attempter = attempter;
    }

    public GuessingSequence GuessRandomNumber() {
      // ToDo: No more than 15 guesses
      var attemptedGuesses = new List<Guess>();

      Guess? currentGuess = null;
      while (!currentGuess.HasValue || !currentGuess.Value.IsCorrectGuess) {
        var nextAttempt = _attemptCalculator.CalculateNextAttempt(currentGuess);
        currentGuess = _attempter.AttemptGuess(nextAttempt);
        attemptedGuesses.Add(currentGuess.Value);
      }

      return new GuessingSequence(attemptedGuesses);
    }
  }
}