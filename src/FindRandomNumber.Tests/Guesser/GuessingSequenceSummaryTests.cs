﻿using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class GuessingSequenceSummaryTests {
    Guess[] _guesses;
    GuessingSequence _sequence;

    [SetUp]
    public void SetUp() {
      _guesses = new[] { new Guess(1, false), new Guess(2, false), new Guess(3, false), new Guess(6, true) };
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