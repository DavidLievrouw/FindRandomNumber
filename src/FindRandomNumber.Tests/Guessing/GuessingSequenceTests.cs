using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FindRandomNumber.Guessing {
  [TestFixture]
  public class GuessingSequenceTests {
    IEnumerable<Guess> _guesses;
    GuessingSequence _sut;

    [SetUp]
    public void SetUp() {
      _guesses = new[] { new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue), new Guess(6.AsAttempt(), RelationToTargetValue.Correct) };
      _sut = new GuessingSequence(_guesses);
    }

    [TestFixture]
    public class Construction : GuessingSequenceTests {
      [Test]
      public void GivenNullGuesses_Throws() {
        Assert.Throws<ArgumentNullException>(() => new GuessingSequence(null));
      }

      [Test]
      public void GivenZeroGuesses_Throws() {
        Assert.Throws<ArgumentException>(() => new GuessingSequence(new Guess[0]));
      }
    }

    [TestFixture]
    public class GetSummary : GuessingSequenceTests {
      [Test]
      public void BuildsGuessingSummaryWithExpectedValues() {
        var actual = _sut.GetSummary();
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.GuessedNumber, Is.EqualTo(6));
        Assert.That(actual.NumberOfAttempts, Is.EqualTo(4));
      }
    }
  }
}