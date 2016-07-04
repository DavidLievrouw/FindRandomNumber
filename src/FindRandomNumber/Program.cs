using System;

namespace FindRandomNumber {
  public class Program {
    static IFindRandomNumberProgram _findRandomNumberProgram;

    static void Main(string[] args) {
      _findRandomNumberProgram = new FindRandomNumberProgram();
      _findRandomNumberProgram.Run();
      Console.WriteLine("Press any key to quit...");
      Console.ReadKey();
    }
  }
}