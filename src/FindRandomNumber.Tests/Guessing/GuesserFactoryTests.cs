using System;
using FakeItEasy;
using FindRandomNumber.Guessing.AttemptCalculation;
using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuesserFactoryTests {
    IAttemptCalculator _attemptCalculator;
    GuesserFactory _sut;

    [SetUp]
    public virtual void SetUp() {
      _attemptCalculator = A.Fake<IAttemptCalculator>();
      _sut = new GuesserFactory(_attemptCalculator);
    }

    [TestFixture]
    public class Construction : GuesserFactoryTests {
      [Test]
      public void GivenNullAttemptCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new GuesserFactory(null));
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