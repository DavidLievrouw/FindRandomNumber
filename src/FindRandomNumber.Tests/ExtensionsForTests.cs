using FindRandomNumber.Guesser;

namespace FindRandomNumber {
  public static class ExtensionsForTests {
    public static Attempt AsAttempt(this short attemptValue) {
      return new Attempt(attemptValue, new Range());
    }

    public static Attempt AsAttempt(this int attemptValue) {
      return new Attempt((short)attemptValue, new Range());
    }
  }
}