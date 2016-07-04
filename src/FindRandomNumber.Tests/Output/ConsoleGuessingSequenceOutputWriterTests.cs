using System;
using FakeItEasy;
using FindRandomNumber.Guessing;
using NUnit.Framework;

namespace FindRandomNumber.Output {
  [TestFixture]
  public class ConsoleGuessingSequenceOutputWriterTests {
    IConsole _console;
    ConsoleGuessingSequenceOutputWriter _sut;

    [SetUp]
    public virtual void SetUp() {
      _console = A.Fake<IConsole>();
      _sut = new ConsoleGuessingSequenceOutputWriter(_console);
    }

    [TestFixture]
    public class Construction : ConsoleGuessingSequenceOutputWriterTests {
      [Test]
      public void GivenNullConsole_Throws() {
        Assert.Throws<ArgumentNullException>(() => new ConsoleGuessingSequenceOutputWriter(null));
      }
    }

    [TestFixture]
    public class Write : ConsoleGuessingSequenceOutputWriterTests {
      Guess[] _guesses;
      GuessingSequence _sequence;

      [SetUp]
      public override void SetUp() {
        base.SetUp();
        _guesses = new[] { new Guess(1.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(2.AsAttempt(), RelationToTargetValue.LessThanTargetValue), new Guess(8.AsAttempt(), RelationToTargetValue.GreaterThanTargetValue), new Guess(6.AsAttempt(), RelationToTargetValue.Correct) };
        _sequence = new GuessingSequence(_guesses);
      }

      [Test]
      public void GivenNullSequence_Throws() {
        Assert.Throws<ArgumentNullException>(() => _sut.Write(null));
      }

      [Test]
      public void WritesOrderedGuessesToConsole() {
        _sut.Write(_sequence);

        A.CallTo(() => _console.WriteLine(_guesses[0].ToString())).MustHaveHappened()
          .Then(A.CallTo(() => _console.WriteLine(_guesses[1].ToString())).MustHaveHappened())
          .Then(A.CallTo(() => _console.WriteLine(_guesses[2].ToString())).MustHaveHappened())
          .Then(A.CallTo(() => _console.WriteLine(_guesses[3].ToString())).MustHaveHappened());
      }

      [Test]
      public void WritesSummaryToConsole() {
        _sut.Write(_sequence);
        A.CallTo(() => _console.WriteLine(_sequence.GetSummary().ToString())).MustHaveHappened();
      }
    }
  }
}