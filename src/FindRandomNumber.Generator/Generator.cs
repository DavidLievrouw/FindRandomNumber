using System;

namespace FindRandomNumber.Generator {
  public class Generator : IGenerator {
    readonly short _minValue;
    readonly short _maxValue;

    public Generator(short minValue, short maxValue) {
      if (maxValue < minValue) throw new ArgumentOutOfRangeException(nameof(maxValue), "The maximum value is less than the minimum value.");
      if (maxValue >= short.MaxValue) throw new ArgumentOutOfRangeException(nameof(maxValue), $"The maximum value is {short.MaxValue - 1}.");
      _minValue = minValue;
      _maxValue = maxValue;
    }

    public RandomNumber Generate() {
      return (RandomNumber)(short)new Random().Next(_minValue, _maxValue + 1);
    }
  }
}