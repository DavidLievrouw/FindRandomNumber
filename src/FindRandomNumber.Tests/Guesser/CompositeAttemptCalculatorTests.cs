using System;
using FakeItEasy;
using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class CompositeAttemptCalculatorTests {
    IAttemptCalculator _noPreviousGuessAttemptCalculator;
    IAttemptCalculator _previousGuessTooLowAttemptCalculator;
    IAttemptCalculator _previousGuessTooHighAttemptCalculator;
    CompositeAttemptCalculator _sut;

    [SetUp]
    public virtual void SetUp() {
      _noPreviousGuessAttemptCalculator = A.Fake<IAttemptCalculator>();
      _previousGuessTooLowAttemptCalculator = A.Fake<IAttemptCalculator>();
      _previousGuessTooHighAttemptCalculator = A.Fake<IAttemptCalculator>();
      _sut = new CompositeAttemptCalculator(
        _noPreviousGuessAttemptCalculator,
        _previousGuessTooLowAttemptCalculator,
        _previousGuessTooHighAttemptCalculator);
    }

    [TestFixture]
    public class Construction : CompositeAttemptCalculatorTests {
      [Test]
      public void GivenAnyInnerCalculatorIsNull_Throws() {
        Assert.Throws<ArgumentNullException>(() => new CompositeAttemptCalculator(
          null,
          _previousGuessTooLowAttemptCalculator,
          _previousGuessTooHighAttemptCalculator));
        Assert.Throws<ArgumentNullException>(() => new CompositeAttemptCalculator(
          _noPreviousGuessAttemptCalculator,
          null,
          _previousGuessTooHighAttemptCalculator));
        Assert.Throws<ArgumentNullException>(() => new CompositeAttemptCalculator(
          _noPreviousGuessAttemptCalculator,
          _previousGuessTooLowAttemptCalculator,
          null));
      }
    }

    [TestFixture]
    public class CalculateNextAttempt : CompositeAttemptCalculatorTests {
      Attempt _noPreviousAttemptResult;
      Attempt _previousAttemptTooLowResult;
      Attempt _previousAttemptTooHighResult;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _noPreviousAttemptResult = new Attempt(1, new Range());
        A.CallTo(() => _noPreviousGuessAttemptCalculator.CalculateNextAttempt(null)).Returns(_noPreviousAttemptResult);
        _previousAttemptTooLowResult = new Attempt(2, new Range());
        A.CallTo(() => _previousGuessTooLowAttemptCalculator.CalculateNextAttempt(A<Guess>._)).Returns(_previousAttemptTooLowResult);
        _previousAttemptTooHighResult = new Attempt(3, new Range());
        A.CallTo(() => _previousGuessTooHighAttemptCalculator.CalculateNextAttempt(A<Guess>._)).Returns(_previousAttemptTooHighResult);
      }

      [Test]
      public void GivenNullPreviousAttempt_CallsNoPreviousAttemptCalculator() {
        var actual = _sut.CalculateNextAttempt(null);

        Assert.That(actual, Is.EqualTo(_noPreviousAttemptResult));
        A.CallTo(() => _noPreviousGuessAttemptCalculator.CalculateNextAttempt(null)).MustHaveHappened();
        A.CallTo(() => _previousGuessTooLowAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
        A.CallTo(() => _previousGuessTooHighAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
      }

      [Test]
      public void GivenPreviousAttemptWasTooLow_CallsPreviousAttemptTooLowCalculator() {
        var previousGuess = new Guess(new Attempt(20, new Range()), Relation.LowerThanTarget);

        var actual = _sut.CalculateNextAttempt(previousGuess);

        Assert.That(actual, Is.EqualTo(_previousAttemptTooLowResult));
        A.CallTo(() => _noPreviousGuessAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
        A.CallTo(() => _previousGuessTooLowAttemptCalculator.CalculateNextAttempt(previousGuess)).MustHaveHappened();
        A.CallTo(() => _previousGuessTooHighAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
      }

      [Test]
      public void GivenPreviousAttemptWasTooHigh_CallsPreviousAttemptTooHighCalculator() {
        var previousGuess = new Guess(new Attempt(20, new Range()), Relation.GreaterThanTarget);

        var actual = _sut.CalculateNextAttempt(previousGuess);

        Assert.That(actual, Is.EqualTo(_previousAttemptTooHighResult));
        A.CallTo(() => _noPreviousGuessAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
        A.CallTo(() => _previousGuessTooLowAttemptCalculator.CalculateNextAttempt(A<Guess?>._)).MustNotHaveHappened();
        A.CallTo(() => _previousGuessTooHighAttemptCalculator.CalculateNextAttempt(previousGuess)).MustHaveHappened();
      }
    }
  }
}