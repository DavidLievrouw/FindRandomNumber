using FindRandomNumber.Guesser;

namespace FindRandomNumber.Output {
  public interface IGuessingSequenceOutputWriter {
    void Write(GuessingSequence guessingSequence);
  }
}