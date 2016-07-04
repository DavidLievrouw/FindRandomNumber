namespace FindRandomNumber.Guesser {
  public interface IGuesserFactory {
    IGuesser Create(short valueToGuess);
  }
}