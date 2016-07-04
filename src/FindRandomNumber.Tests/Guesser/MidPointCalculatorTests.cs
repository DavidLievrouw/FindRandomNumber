using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class MidPointCalculatorTests {
    MidPointCalculator _sut;

    [SetUp]
    public void SetUp() {
      _sut = new MidPointCalculator();
    }

    [TestFixture]
    public class CalculateMidPoint : MidPointCalculatorTests {
      [Test]
      public void GivenEmptyRange_ReturnsZero() {
        var actual = _sut.CalculateMidPoint(new Range(30, 30));
        Assert.That(actual, Is.EqualTo(30));
      }

      [Test]
      public void GivenRangeThatDiffersOnlyOneNumber_ReturnsMaximum() {
        var actual = _sut.CalculateMidPoint(new Range(20, 21));
        Assert.That(actual, Is.EqualTo(21));
      }

      [TestCase(-100, 100, 0)]
      [TestCase(10, 20, 15)]
      [TestCase(11, 22, 17)]
      [TestCase(-1000, 0, -500)]
      public void GivenRange_ReturnsMidPoint(short minimum, short maximum, short midPoint) {
        var actual = _sut.CalculateMidPoint(new Range(minimum, maximum));
        Assert.That(actual, Is.EqualTo(midPoint));
      }
    }
  }
}