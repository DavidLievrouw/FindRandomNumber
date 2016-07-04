using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuessTests {
    [TestFixture]
    public class ToStringOverride : GuessTests {
      [Test]
      public void ReturnsExpectedString_ForIncorrectGuess() {
        var sut = new Guess(123.AsAttempt(), Relation.Smaller);
        var expected = "Proposing number “123”... incorrect.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }

      [Test]
      public void ReturnsExpectedString_ForCorrectGuess() {
        var sut = new Guess(1234.AsAttempt(), Relation.Correct);
        var expected = "Proposing number “1234”... correct.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }
    }

    [TestFixture]
    public class IsCorrectGuess : GuessTests {
      [TestCase(Relation.Correct, true)]
      [TestCase(Relation.Larger, false)]
      [TestCase(Relation.Smaller, false)]
      public void DeterminesResultBasedOnRelation(Relation relation, bool expected) {
        var sut = new Guess(1234.AsAttempt(), relation);
        var actual = sut.IsCorrectGuess;
        Assert.That(actual, Is.EqualTo(expected));
      }
    }
  }
}