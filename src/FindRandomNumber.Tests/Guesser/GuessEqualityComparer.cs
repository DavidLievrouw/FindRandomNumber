using System;
using System.Collections.Generic;

namespace FindRandomNumber.Guesser {
  public class GuessEqualityComparer : IEqualityComparer<Guess> {
    public bool Equals(Guess x, Guess y) {
      return x.Attempt.Value == y.Attempt.Value && x.RelationToCorrectAnswer == y.RelationToCorrectAnswer;
    }

    public int GetHashCode(Guess obj) {
      throw new NotSupportedException();
    }
  }
}