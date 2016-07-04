using FindRandomNumber.Guessing;

namespace FindRandomNumber.Output {
  public interface IGuessingSequenceOutputWriter {
    void Write(GuessingSequence guessingSequence);
  }
}