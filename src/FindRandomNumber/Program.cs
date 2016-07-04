using System;
using System.Configuration;

namespace FindRandomNumber {
  public class Program {
    static IFindRandomNumberProgram _findRandomNumberProgram;

    static void Main(string[] args) {
      var minValue = short.Parse(ConfigurationManager.AppSettings["MinValue"]);
      var maxValue = short.Parse(ConfigurationManager.AppSettings["MaxValue"]);
      _findRandomNumberProgram = new FindRandomNumberProgram(
        new Generator.Generator(minValue, maxValue),
        new Guesser.GuesserFactory(minValue, maxValue));

      _findRandomNumberProgram.Run();

      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}