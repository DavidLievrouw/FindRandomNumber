using System;
using NUnit.Framework;

namespace FindRandomNumber.Generator {
  [TestFixture]
  public class GeneratorTests {
    short _minValue;
    short _maxValue;
    Generator _sut;

    [SetUp]
    public virtual void SetUp() {
      _minValue = 100;
      _maxValue = 10000;
      _sut = new Generator(_minValue, _maxValue);
    }

    [TestFixture]
    public class Construction : GeneratorTests {
      [Test]
      public void GivenMaxValueSmallerThanMinValue_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Generator(_minValue, (short)(_minValue - 1)));
      }
    }
  }
}