using System;
using FindRandomNumber.Generator;
using FindRandomNumber.Guesser;

namespace FindRandomNumber {
  public class FindRandomNumberProgram : IFindRandomNumberProgram {
    readonly IGenerator _generator;
    readonly IGuesser _guesser;

    public FindRandomNumberProgram(IGenerator generator, IGuesser guesser) {
      if (generator == null) throw new ArgumentNullException(nameof(generator));
      if (guesser == null) throw new ArgumentNullException(nameof(guesser));
      _generator = generator;
      _guesser = guesser;
    }

    public void Run() {
      var randomNumberToGuess = _generator.Generate();

    }
  }
}