using System;
using FindRandomNumber.Generation;
using FindRandomNumber.Guessing;
using FindRandomNumber.Output;

namespace FindRandomNumber {
  public class FindRandomNumberProgram : IFindRandomNumberProgram {
    readonly IGenerator _generator;
    readonly IGuesserFactory _guesserFactory;
    readonly IGuessingSequenceOutputWriter _guessingSequenceOutputWriter;

    public FindRandomNumberProgram(IGenerator generator, IGuesserFactory guesserFactory, IGuessingSequenceOutputWriter guessingSequenceOutputWriter) {
      if (generator == null) throw new ArgumentNullException(nameof(generator));
      if (guesserFactory == null) throw new ArgumentNullException(nameof(guesserFactory));
      if (guessingSequenceOutputWriter == null) throw new ArgumentNullException(nameof(guessingSequenceOutputWriter));
      _generator = generator;
      _guesserFactory = guesserFactory;
      _guessingSequenceOutputWriter = guessingSequenceOutputWriter;
    }

    public void Run() {
      var randomNumberToGuess = _generator.Generate();
      var guesser = _guesserFactory.Create(randomNumberToGuess.Value);
      var guessingSequence = guesser.GuessRandomNumber();
      _guessingSequenceOutputWriter.Write(guessingSequence);
    }
  }
}