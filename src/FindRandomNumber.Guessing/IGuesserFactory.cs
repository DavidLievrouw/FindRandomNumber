namespace FindRandomNumber.Guessing {
  public interface IGuesserFactory {
    IGuesser Create(short valueToGuess);
  }
}