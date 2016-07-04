using System;
using System.Collections;
using System.Collections.Generic;

namespace FindRandomNumber.Guesser {
  public class GuessingSequence : IEnumerable<Guess> {
    readonly IEnumerable<Guess> _guesses;

    public GuessingSequence(IEnumerable<Guess> guesses) {
      if (guesses == null) throw new ArgumentNullException(nameof(guesses));
      _guesses = guesses;
    }

    public IEnumerator<Guess> GetEnumerator() {
      return _guesses.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return _guesses.GetEnumerator();
    }
  }
}