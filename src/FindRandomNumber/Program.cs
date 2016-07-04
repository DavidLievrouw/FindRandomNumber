using System;
using System.Configuration;
using FindRandomNumber.Guesser;
using FindRandomNumber.Output;

namespace FindRandomNumber {
  public class Program {
    static IFindRandomNumberProgram _findRandomNumberProgram;

    static void Main(string[] args) {
      var minValue = short.Parse(ConfigurationManager.AppSettings["MinValue"]);
      var maxValue = short.Parse(ConfigurationManager.AppSettings["MaxValue"]);
      var range = new Range(minValue, maxValue);

      _findRandomNumberProgram = new FindRandomNumberProgram(
        new Generator.Generator(minValue, maxValue), // ToDo: Range and extensions in common library
        new GuesserFactory(new AttemptCalculator(range)),
        new ConsoleGuessingSequenceOutputWriter(new RealConsole()));

      _findRandomNumberProgram.Run();

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}