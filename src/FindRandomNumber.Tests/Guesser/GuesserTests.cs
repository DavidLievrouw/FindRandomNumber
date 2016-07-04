using System;
using FakeItEasy;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuesserTests {
    IAttemptCalculator _attemptCalculator;
    IGuessAttempter _guessAttempter;
    Guesser _sut;

    [SetUp]
    public void SetUp() {
      _attemptCalculator = A.Fake<IAttemptCalculator>();
      _guessAttempter = A.Fake<IGuessAttempter>();
      _sut = new Guesser(_attemptCalculator, _guessAttempter);
    }

    [TestFixture]
    public class Construction : GuesserTests {
      [Test]
      public void GivenNullAttemptCalculator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Guesser(null, _guessAttempter));
      }

      [Test]
      public void GivenNullAttempter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new Guesser(_attemptCalculator, null));
      }
    }

    [TestFixture]
    public class GuessRandomNumber : GuesserTests {
      [Test]
      public void GivenFirstAttemptOk_ReturnsExpectedGuessingSequence() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(2.AsAttempt(), 3.AsAttempt(), 4.AsAttempt());
        A.CallTo(() => _guessAttempter.AttemptGuess(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(2.AsAttempt(), Relation.Correct),
            new Guess(3.AsAttempt(), Relation.GreaterThanTarget),
            new Guess(4.AsAttempt(), Relation.GreaterThanTarget));

        var expectedSequence = new GuessingSequence(new[] { new Guess(2.AsAttempt(), Relation.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void AttemptsUntilAttemptIsCorrect() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(1.AsAttempt(), 2.AsAttempt(), 8.AsAttempt(), 6.AsAttempt(), 10.AsAttempt());
        A.CallTo(() => _guessAttempter.AttemptGuess(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(1.AsAttempt(), Relation.LowerThanTarget),
            new Guess(2.AsAttempt(), Relation.LowerThanTarget),
            new Guess(8.AsAttempt(), Relation.GreaterThanTarget),
            new Guess(6.AsAttempt(), Relation.Correct),
            new Guess(10.AsAttempt(), Relation.GreaterThanTarget));

        var expectedSequence = new GuessingSequence(new[] { new Guess(1.AsAttempt(), Relation.LowerThanTarget), new Guess(2.AsAttempt(), Relation.LowerThanTarget), new Guess(8.AsAttempt(), Relation.GreaterThanTarget), new Guess(6.AsAttempt(), Relation.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void DoesNotGuessAnyFurther_WhenACorrectGuessWasAttempted() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(1.AsAttempt(), 2.AsAttempt(), 8.AsAttempt(), 6.AsAttempt(), 10.AsAttempt());
        A.CallTo(() => _guessAttempter.AttemptGuess(A<Attempt>._))
          .ReturnsNextFromSequence(
            new Guess(1.AsAttempt(), Relation.LowerThanTarget),
            new Guess(2.AsAttempt(), Relation.LowerThanTarget),
            new Guess(8.AsAttempt(), Relation.GreaterThanTarget),
            new Guess(6.AsAttempt(), Relation.Correct),
            new Guess(10.AsAttempt(), Relation.GreaterThanTarget));

        _sut.GuessRandomNumber();

        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>.That.Matches(guess => guess.HasValue && guess.Value.Attempt.Value == 6))).MustNotHaveHappened();
        A.CallTo(() => _guessAttempter.AttemptGuess(A<Attempt>.That.Matches(attempt => attempt.Value == 10))).MustNotHaveHappened();
      }
    }
  }
}