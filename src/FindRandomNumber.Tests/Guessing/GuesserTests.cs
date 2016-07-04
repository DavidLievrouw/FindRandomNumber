using System;
using FakeItEasy;
using FindRandomNumber.Guessing.AttemptCalculation;
using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuesserTests {
    IAttemptCalculator _attemptCalculator;
    IAttemptPerformer _attemptPerformer;
    Guessing.Guesser _sut;

    [SetUp]
    public void SetUp() {
      _attemptCalculator = A.Fake<IAttemptCalculator>();
      _attemptPerformer = A.Fake<IAttemptPerformer>();
      _sut = new Guessing.Guesser(_attemptCalculator, _attemptPerformer);
    }

    [TestFixture]
    public class Construction : GuesserTests {
      [Test]
      public void GivenNullAttemptCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Guessing.Guesser(null, _attemptPerformer));
      }

      [Test]
      public void GivenNullAttempter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Guessing.Guesser(_attemptCalculator, null));
      }
    }

    [TestFixture]
    public class GuessRandomNumber : GuesserTests {
      [Test]
      public void GivenFirstAttemptOk_ReturnsExpectedGuessingSequence() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(2.AsAttempt(), 3.AsAttempt(), 4.AsAttempt());
        A.CallTo(() => _attemptPerformer.PerformAttempt(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(2.AsAttempt(), RelationToTargetValue.Correct),
            new Guess(3.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue),
            new Guess(4.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue));

        var expectedSequence = new GuessingSequence(new[] { new Guess(2.AsAttempt(), RelationToTargetValue.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void AttemptsUntilAttemptIsCorrect() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(1.AsAttempt(), 2.AsAttempt(), 8.AsAttempt(), 6.AsAttempt(), 10.AsAttempt());
        A.CallTo(() => _attemptPerformer.PerformAttempt(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue),
            new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue),
            new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue),
            new Guess(6.AsAttempt(), RelationToTargetValue.Correct),
            new Guess(10.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue));

        var expectedSequence = new GuessingSequence(new[] { new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue), new Guess(6.AsAttempt(), RelationToTargetValue.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void DoesNotGuessAnyFurther_WhenACorrectGuessWasAttempted() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(1.AsAttempt(), 2.AsAttempt(), 8.AsAttempt(), 6.AsAttempt(), 10.AsAttempt());
        A.CallTo(() => _attemptPerformer.PerformAttempt(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue),
            new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue),
            new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue),
            new Guess(6.AsAttempt(), RelationToTargetValue.Correct),
            new Guess(10.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue));

        _sut.GuessRandomNumber();

        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>.That.Matches(guess => guess.HasValue && guess.Value.Attempt.Value == 6))).MustNotHaveHappened();
        A.CallTo(() => _attemptPerformer.PerformAttempt(A<Attempt>.That.Matches(attempt => attempt.Value == 10))).MustNotHaveHappened();
      }
    }
  }
}