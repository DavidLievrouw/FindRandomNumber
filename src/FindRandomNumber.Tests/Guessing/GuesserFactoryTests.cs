using System;
using FakeItEasy;
using FindRandomNumber.Guessing.AttemptCalculation;
using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuesserFactoryTests {
    IAttemptCalculator _attemptCalculator;
    int _maxAttempts;
    GuesserFactory _sut;

    [SetUp]
    public virtual void SetUp() {
      _attemptCalculator = A.Fake<IAttemptCalculator>();
      _maxAttempts = 5;
      _sut = new GuesserFactory(_attemptCalculator, _maxAttempts);
    }

    [TestFixture]
    public class Construction : GuesserFactoryTests {
      [Test]
      public void GivenNullAttemptCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new GuesserFactory(null, _maxAttempts));
      }

      [TestCase(0)]
      [TestCase(-11)]
      [TestCase(-20)]
      public void GivenInvalidMaxAttempts_Throws(int invalidMaxAttempts) {
        Assert.Throws<ArgumentOutOfRangeException>(() => new GuesserFactory(_attemptCalculator, invalidMaxAttempts));
      }
    }

    [TestFixture]
    public class Create : GuesserFactoryTests {
      short _valueToGuess;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _valueToGuess = 12;
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