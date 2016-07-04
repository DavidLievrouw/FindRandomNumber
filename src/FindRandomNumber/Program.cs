using System;
using System.Configuration;
using FindRandomNumber.Common;
using FindRandomNumber.Guesser;
using FindRandomNumber.Output;

namespace FindRandomNumber {
  public class Program {
    static void Main(string[] args) {
      var findRandomNumberProgram = ComposeProgram();
      findRandomNumberProgram.Run();

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }

    static IFindRandomNumberProgram ComposeProgram() {
      var minValue = short.Parse(ConfigurationManager.AppSettings["MinValue"]);
      var maxValue = short.Parse(ConfigurationManager.AppSettings["MaxValue"]);
      var range = new Range(minValue, maxValue);

      return new FindRandomNumberProgram(
        new Generator.Generator(range),
        new GuesserFactory(new AttemptCalculator(range)),
        new ConsoleGuessingSequenceOutputWriter(new RealConsole()));
    }
  }
}