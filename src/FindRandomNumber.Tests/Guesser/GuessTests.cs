using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuessTests {
    [TestFixture]
    public class ToStringOverride : GuessTests {
      [Test]
      public void ReturnsExpectedString_ForIncorrectGuess() {
        var sut = new Guess(123, false);
        var expected = "Proposing number “123”... incorrect.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }

      [Test]
      public void ReturnsExpectedString_ForCorrectGuess() {
        var sut = new Guess(1234, true);
        var expected = "Proposing number “1234”... correct.";
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }
    }
  }
}