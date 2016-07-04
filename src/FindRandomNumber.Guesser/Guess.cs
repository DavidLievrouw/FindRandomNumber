namespace FindRandomNumber.Guesser {
  public class Guess {
    public Guess(short guessedValue, bool isCorrectGuess) {
      GuessedValue = guessedValue;
      IsCorrectGuess = isCorrectGuess;
    }

    public short GuessedValue { get; }  
    public bool IsCorrectGuess { get; }
  }
}