using System;
using System.Collections.Generic;

namespace FindRandomNumber.Guessing {
  public class GuessEqualityComparer : IEqualityComparer<Guess> {
    public bool Equals(Guess x, Guess y) {
      return x.Attempt.Value == y.Attempt.Value && x.RelationToTargetValue == y.RelationToTargetValue;
    }

    public int GetHashCode(Guess obj) {
      throw new NotSupportedException();
    }
  }
}