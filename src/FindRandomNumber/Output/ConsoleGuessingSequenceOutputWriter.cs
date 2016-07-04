using System;
using FindRandomNumber.Guesser;

namespace FindRandomNumber.Output {
  public class ConsoleGuessingSequenceOutputWriter : IGuessingSequenceOutputWriter {
    readonly IConsole _console;

    public ConsoleGuessingSequenceOutputWriter(IConsole console) {
      if (console == null) throw new ArgumentNullException(nameof(console));
      _console = console;
    }

    public void Write(GuessingSequence guessingSequence) {
      if (guessingSequence == null) throw new ArgumentNullException(nameof(guessingSequence));
      throw new NotImplementedException();
    }
  }
}