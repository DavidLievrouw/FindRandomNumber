using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FindRandomNumber.Guesser {
  public class GuessingSequence : IEnumerable<Guess> {
    readonly List<Guess> _guesses;

    public GuessingSequence(IEnumerable<Guess> guesses) {
      if (guesses == null) throw new ArgumentNullException(nameof(guesses));
      _guesses = guesses.ToList();
      if (!_guesses.Any()) throw new ArgumentException("No guesses are specified.", nameof(guesses));
    }

    public IEnumerator<Guess> GetEnumerator() {
      return _guesses.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return _guesses.GetEnumerator();
    }

    public GuessingSequenceSummary GetSummary() {
      return new GuessingSequenceSummary(
        _guesses.Count,
        _guesses.Last().GuessedValue);
    }

    public class GuessingSequenceSummary {
      public GuessingSequenceSummary(int numberOfAttempts, short guessedNumber) {
        NumberOfAttempts = numberOfAttempts;
        GuessedNumber = guessedNumber;
      }

      public int NumberOfAttempts { get; }
      public short GuessedNumber { get; }

      public override string ToString() {
        return $"Guessed the number “{GuessedNumber}” after {NumberOfAttempts} attempts.";
      }
    }
  }
}