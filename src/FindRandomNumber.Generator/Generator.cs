using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Generation {
  public class Generator : IGenerator {
    readonly Range _range;

    public Generator(Range range) {
      if (range.Maximum >= short.MaxValue) throw new ArgumentOutOfRangeException(nameof(range), $"The maximum allowed value is {short.MaxValue - 1}.");
      _range = range;
    }

    public RandomNumber Generate() {
      return (RandomNumber)(short)new Random().Next(_range.Minimum, _range.Maximum + 1);
    }
  }
}