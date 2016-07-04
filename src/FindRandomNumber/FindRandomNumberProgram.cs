using System;
using FindRandomNumber.Generator;

namespace FindRandomNumber {
  public class FindRandomNumberProgram : IFindRandomNumberProgram {
    readonly IGenerator _generator;

    public FindRandomNumberProgram(IGenerator generator) {
      if (generator == null) throw new ArgumentNullException(nameof(generator));
      _generator = generator;
    }

    public void Run() {
      var randomNumberToGuess = _generator.Generate();
    }
  }
}