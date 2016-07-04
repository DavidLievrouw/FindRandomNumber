using System;
using FakeItEasy;
using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  [TestFixture]
  public class NoPreviousGuessAttemptCalculatorTests {
    IMidPointCalculator _midPointCalculator;
    Range _fullRange;
    NoPreviousGuessAttemptCalculator _sut;

    [SetUp]
    public virtual void SetUp() {
      _midPointCalculator = A.Fake<IMidPointCalculator>();
      _fullRange = new Range(10, 200);
      _sut = new NoPreviousGuessAttemptCalculator(_midPointCalculator, _fullRange);
    }

    [TestFixture]
    public class Construction : NoPreviousGuessAttemptCalculatorTests {
      [Test]
      public void GivenNullMidPointCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new NoPreviousGuessAttemptCalculator(null, _fullRange));
      }
    }

    [TestFixture]
    public class CalculateNextAttempt : NoPreviousGuessAttemptCalculatorTests {
      short _midPoint;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _midPoint = 105;
        A.CallTo(() => _midPointCalculator.CalculateMidPoint(_fullRange)).Returns(_midPoint);
      }

      [Test]
      public void ReturnsRandomAttemptWithinFullRange() {
        var actual = _sut.CalculateNextAttempt(null);
        Assert.That(actual.Value, Is.InRange(_fullRange.Minimum, _fullRange.Maximum));
        Assert.That(actual.Range.Minimum, Is.EqualTo(_fullRange.Minimum));
        Assert.That(actual.Range.Maximum, Is.EqualTo(_fullRange.Maximum));
      }
    }
  }
}