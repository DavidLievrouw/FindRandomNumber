using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuessAttempterTests {
    short _valueToGuess;
    GuessAttempter _sut;

    [SetUp]
    public void SetUp() {
      _valueToGuess = 123;
      _sut = new GuessAttempter(_valueToGuess);
    }

    [TestFixture]
    public class AttemptGuess : GuessAttempterTests {
      [Test]
      public void GivenCorrectGuess_ReturnsGuessThatRepresentsCorrectAttempt() {
        var attempt = _valueToGuess.AsAttempt();
        var expected = new Guess(attempt, Relation.Correct);
        var actual = _sut.AttemptGuess(attempt);
        Assert.That(actual, Is.EqualTo(expected).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void GivenSmallerNumberGuess_ReturnsGuessThatRepresentsFailedAttempt() {
        var attempt = ((short)(_valueToGuess - 1)).AsAttempt();
        var expected = new Guess(attempt, Relation.Smaller);
        var actual = _sut.AttemptGuess(attempt);
        Assert.That(actual, Is.EqualTo(expected).Using(new GuessEqualityComparer()));
      }

      [Test]
      public void GivenLargerNumberGuess_ReturnsGuessThatRepresentsFailedAttempt() {
        var attempt = ((short)(_valueToGuess + 1)).AsAttempt();
        var expected = new Guess(attempt, Relation.Larger);
        var actual = _sut.AttemptGuess(attempt);
        Assert.That(actual, Is.EqualTo(expected).Using(new GuessEqualityComparer()));
      }
    }
  }
}