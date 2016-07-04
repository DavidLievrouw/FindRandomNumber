using System;
using FindRandomNumber.Common;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  public class MidPointCalculator : IMidPointCalculator {
    public short CalculateMidPoint(Range range) {
      return (short)Math.Round((range.Minimum + range.Maximum) / 2.0, 0, MidpointRounding.AwayFromZero);
    }
  }
}