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
          .ReturnsNextFromSequence(new short[] { 2, 3, 4 });
        A.CallTo(() => _guessAttempter.AttemptGuess(A<short>._))
          .ReturnsNextFromSequence(
            new Guess(2, Relation.Correct),
            new Guess(3, Relation.Larger),
            new Guess(4, Relation.Larger));

        var expectedSequence = new GuessingSequence(new[] { new Guess(2, Relation.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void AttemptsUntilAttemptIsCorrect() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(new short[] { 1, 2, 8, 6, 10 });
        A.CallTo(() => _guessAttempter.AttemptGuess(A<short>._))
          .ReturnsNextFromSequence(
            new Guess(1, Relation.Smaller),
            new Guess(2, Relation.Smaller),
            new Guess(8, Relation.Larger),
            new Guess(6, Relation.Correct),
            new Guess(10, Relation.Larger));

        var expectedSequence = new GuessingSequence(new[] { new Guess(1, Relation.Smaller), new Guess(2, Relation.Smaller), new Guess(8, Relation.Larger), new Guess(6, Relation.Correct) });

        var actual = _sut.GuessRandomNumber();

        Assert.That(actual, Is.EquivalentTo(expectedSequence).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void DoesNotGuessAnyFurther_WhenACorrectGuessWasAttempted() {
        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>._))
          .ReturnsNextFromSequence(new short[] { 1, 2, 8, 6, 10 });
        A.CallTo(() => _guessAttempter.AttemptGuess(A<short>._))
          .ReturnsNextFromSequence(
            new Guess(1, Relation.Smaller),
            new Guess(2, Relation.Smaller),
            new Guess(8, Relation.Larger),
            new Guess(6, Relation.Correct),
            new Guess(10, Relation.Larger));

        _sut.GuessRandomNumber();

        A.CallTo(() => _attemptCalculator.CalculateNextAttempt(A<Guess?>.That.Matches(guess => guess.HasValue && guess.Value.GuessedValue == 6))).MustNotHaveHappened();
        A.CallTo(() => _guessAttempter.AttemptGuess(10)).MustNotHaveHappened();
      }
    }
  }
}