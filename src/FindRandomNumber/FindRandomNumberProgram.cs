using System;
using FindRandomNumber.Generator;
using FindRandomNumber.Guesser;

namespace FindRandomNumber {
  public class FindRandomNumberProgram : IFindRandomNumberProgram {
    readonly IGenerator _generator;
    readonly IGuesserFactory _guesserFactory;

    public FindRandomNumberProgram(IGenerator generator, IGuesserFactory guesserFactory) {
      if (generator == null) throw new ArgumentNullException(nameof(generator));
      if (guesserFactory == null) throw new ArgumentNullException(nameof(guesserFactory));
      _generator = generator;
      _guesserFactory = guesserFactory;
    }

    public void Run() {
      var randomNumberToGuess = _generator.Generate();
      var guesser = _guesserFactory.Create(randomNumberToGuess.Value);
      var guessingSequence = guesser.GuessRandomNumber();

    }
  }
}