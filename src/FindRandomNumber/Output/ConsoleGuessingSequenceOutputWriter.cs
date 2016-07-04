using System;
using FindRandomNumber.Common;
using FindRandomNumber.Guessing;

namespace FindRandomNumber.Output {
  public class ConsoleGuessingSequenceOutputWriter : IGuessingSequenceOutputWriter {
    readonly IConsole _console;

    public ConsoleGuessingSequenceOutputWriter(IConsole console) {
      if (console == null) throw new ArgumentNullException(nameof(console));
      _console = console;
    }

    public void Write(GuessingSequence guessingSequence) {
      if (guessingSequence == null) throw new ArgumentNullException(nameof(guessingSequence));

      guessingSequence.ForEach(guess => _console.WriteLine(guess.ToString()));

      var summary = guessingSequence.GetSummary();
      _console.WriteLine(summary.ToString());
    }
  }
}