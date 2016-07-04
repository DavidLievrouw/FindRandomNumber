using System;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuesserTests {
    short _minValue;
    short _maxValue;
    short _valueToGuess;
    Guesser _sut;

    [SetUp]
    public virtual void SetUp() {
      _minValue = 100;
      _maxValue = 10000;
      _valueToGuess = 5334;
      _sut = new Guesser(_minValue, _maxValue, _valueToGuess);
    }

    [TestFixture]
    public class Construction : GuesserTests {
      [Test]
      public void GivenMaxValueSmallerThanMinValue_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Guesser(_minValue, (short)(_minValue - 1), _valueToGuess));
      }

      [Test]
      public void GivenValueToGuessThatIsOutOfRange_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Guesser(_minValue, _maxValue, (short)(_minValue - 1)));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Guesser(_minValue, _maxValue, (short)(_maxValue + 1)));
      }
    }
  }
}