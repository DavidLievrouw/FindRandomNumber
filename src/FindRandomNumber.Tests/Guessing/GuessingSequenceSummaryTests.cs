using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuessingSequenceSummaryTests {
    Guess[] _guesses;
    GuessingSequence _sequence;

    [SetUp]
    public void SetUp() {
      _guesses = new[] { new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue), new Guess(6.AsAttempt(), RelationToTargetValue.Correct) };
      _sequence = new GuessingSequence(_guesses);
    }

    [TestFixture]
    public class ToStringOverride : GuessingSequenceSummaryTests {
      [Test]
      public void ReturnsExpectedString() {
        var expected = "Guessed the number “6” after 4 attempts.";
        var sut = _sequence.GetSummary();
        var actual = sut.ToString();
        Assert.That(actual, Is.EqualTo(expected));
      }
    }
  }
}