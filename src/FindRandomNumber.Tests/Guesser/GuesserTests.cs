using System;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuesserTests {
    short _minValue;
    short _maxValue;
    Guesser _sut;

    [SetUp]
    public virtual void SetUp() {
      _minValue = 100;
      _maxValue = 10000;
      _sut = new Guesser(_minValue, _maxValue);
    }

    [TestFixture]
    public class Construction : GuesserTests {
      [Test]
      public void GivenMaxValueSmallerThanMinValue_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Guesser(_minValue, (short)(_minValue - 1)));
      }
    }
  }
}