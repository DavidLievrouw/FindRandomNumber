using System;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuesserFactoryTests {
    short _minValue;
    short _maxValue;
    GuesserFactory _sut;

    [SetUp]
    public virtual void SetUp() {
      _minValue = 100;
      _maxValue = 10000;
      _sut = new GuesserFactory(_minValue, _maxValue);
    }

    [TestFixture]
    public class Construction : GuesserFactoryTests {
      [Test]
      public void GivenMaxValueSmallerThanMinValue_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new GuesserFactory(_minValue, (short)(_minValue - 1)));
      }
    }

    [TestFixture]
    public class Create : GuesserFactoryTests {
      short _valueToGuess;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _valueToGuess = (short)(_minValue + 12);
      }

      [Test]
      public void CreatesNewGuesser() {
        var actual = _sut.Create(_valueToGuess);
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.InstanceOf<IGuesser>());
      }
    }
  }
}