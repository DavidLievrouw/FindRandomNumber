using FindRandomNumber.Common;

namespace FindRandomNumber.Guesser {
  public interface IMidPointCalculator {
    short CalculateMidPoint(Range range);
  }
}