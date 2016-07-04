using System;
using FakeItEasy;
using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class PreviousGuessTooHighAttemptCalculatorTests {
    IMidPointCalculator _midPointCalculator;
    PreviousGuessTooHighAttemptCalculator _sut;

    [SetUp]
    public virtual void SetUp() {
      _midPointCalculator = A.Fake<IMidPointCalculator>();
      _sut = new PreviousGuessTooHighAttemptCalculator(_midPointCalculator);
    }

    [TestFixture]
    public class Construction : PreviousGuessTooHighAttemptCalculatorTests {
      [Test]
      public void GivenNullMidPointCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new PreviousGuessTooHighAttemptCalculator(null));
      }
    }

    [TestFixture]
    public class CalculateNextAttempt : PreviousGuessTooHighAttemptCalculatorTests {
      short _midPoint;
      Guess _previousGuess;
      Range _rangeForNextAttempt;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _previousGuess = new Guess(new Attempt(20, new Range(1, 50)), RelationToTargetValue.GreaterThanTargetValue);
        _midPoint = 10;
        _rangeForNextAttempt = new Range(_previousGuess.Attempt.Range.Minimum, (short)(_previousGuess.Attempt.Value - 1));
        A.CallTo(() => _midPointCalculator.CalculateMidPoint(_rangeForNextAttempt)).Returns(_midPoint);
      }

      [Test]
      public void ReturnsRandomAttemptWithinFullRange() {
        var actual = _sut.CalculateNextAttempt(_previousGuess);

        Assert.That(actual.Value, Is.InRange(_rangeForNextAttempt.Minimum, _rangeForNextAttempt.Maximum));
        Assert.That(actual.Range.Minimum, Is.EqualTo(_rangeForNextAttempt.Minimum));
        Assert.That(actual.Range.Maximum, Is.EqualTo(_rangeForNextAttempt.Maximum));
      }
    }
  }
}