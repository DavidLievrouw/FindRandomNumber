using System;
using FakeItEasy;
using FindRandomNumber.Common;
using FindRandomNumber.Generation;
using FindRandomNumber.Guessing;
using FindRandomNumber.Output;
using NUnit.Framework;

namespace FindRandomNumber {
  [TestFixture]
  public class FindRandomNumberProgramTests {
    IGenerator _generator;
    IGuesserFactory _guesserFactory;
    IGuessingSequenceOutputWriter _guessingSequenceOutputWriter;
    FindRandomNumberProgram _sut;

    [SetUp]
    public virtual void SetUp() {
      _generator = A.Fake<IGenerator>();
      _guesserFactory = A.Fake<IGuesserFactory>();
      _guessingSequenceOutputWriter = A.Fake<IGuessingSequenceOutputWriter>();
      _sut = new FindRandomNumberProgram(_generator, _guesserFactory, _guessingSequenceOutputWriter);
    }

    [TestFixture]
    public class Construction : FindRandomNumberProgramTests {
      [Test]
      public void GivenNullGenerator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(null, _guesserFactory, _guessingSequenceOutputWriter));
      }

      [Test]
      public void GivenNullGuesserFactory_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(_generator, null, _guessingSequenceOutputWriter));
      }

      [Test]
      public void GivenNullOutputWriter_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(_generator, _guesserFactory, null));
      }
    }

    [TestFixture]
    public class Run : FindRandomNumberProgramTests {
      [Test]
      public void GeneratesRandomNumber_UsingGenerator() {
        _sut.Run();
        A.CallTo(() => _generator.Generate()).MustHaveHappened();
      }

      [Test]
      public void CreatesGuesser_ThatGuessesTheGeneratedRandomNumber() {
        var numberToGuess = new RandomNumber(123);
        A.CallTo(() => _generator.Generate()).Returns(numberToGuess);

        _sut.Run();

        A.CallTo(() => _guesserFactory.Create(numberToGuess.Value)).MustHaveHappened();
      }

      [Test]
      public void CallsGuesser_ThatGuessesTheGeneratedRandomNumber() {
        var numberToGuess = new RandomNumber(123);
        A.CallTo(() => _generator.Generate()).Returns(numberToGuess);

        var fakeGuesser = A.Fake<IGuesser>();
        A.CallTo(() => _guesserFactory.Create(numberToGuess.Value)).Returns(fakeGuesser);

        _sut.Run();

        A.CallTo(() => fakeGuesser.GuessRandomNumber()).MustHaveHappened();
      }


      [Test]
      public void WritesPerformedGuessingSequence_ToOutputWriter() {
        var numberToGuess = new RandomNumber(123);
        A.CallTo(() => _generator.Generate()).Returns(numberToGuess);

        var fakeGuesser = A.Fake<IGuesser>();
        A.CallTo(() => _guesserFactory.Create(numberToGuess.Value)).Returns(fakeGuesser);

        var performedGuessingSequence = new GuessingSequence(new [] { new Guess(1.AsAttempt(), RelationToTargetValue.Correct) });
        A.CallTo(() => fakeGuesser.GuessRandomNumber()).Returns(performedGuessingSequence);

        _sut.Run();

        A.CallTo(() => _guessingSequenceOutputWriter.Write(performedGuessingSequence)).MustHaveHappened();
      }
    }
  }
}