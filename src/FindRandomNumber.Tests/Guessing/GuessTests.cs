using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuessTests {
    [TestFixture]
    public class ToStringOverride : GuessTests {
      [Test]
      public void ReturnsExpectedString_ForIncorrectGuess() {
        var sut = new Guess(123.AsAttempt(), RelationToTargetValue.LessThanTargetValue);
        var expected = "Proposing number “123”... incorrect.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }

      [Test]
      public void ReturnsExpectedString_ForCorrectGuess() {
        var sut = new Guess(1234.AsAttempt(), RelationToTargetValue.Correct);
        var expected = "Proposing number “1234”... correct.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }
    }

    [TestFixture]
    public class IsCorrectGuess : GuessTests {
      [TestCase(RelationToTargetValue.Correct, true)]
      [TestCase(RelationToTargetValue.GreaterThanTargetValue, false)]
      [TestCase(RelationToTargetValue.LessThanTargetValue, false)]
      public void DeterminesResultBasedOnRelation(RelationToTargetValue relationToTargetValue, bool expected) {
        var sut = new Guess(1234.AsAttempt(), relationToTargetValue);
        var actual = sut.IsCorrectGuess;
        Assert.That(actual, Is.EqualTo(expected));
      }
    }
  }
}