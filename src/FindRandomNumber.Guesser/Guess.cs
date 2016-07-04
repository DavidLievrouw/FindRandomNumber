namespace FindRandomNumber.Guesser {
  public struct Guess {
    public Guess(short guessedValue, Relation relationToCorrectAnswer) {
      GuessedValue = guessedValue;
      RelationToCorrectAnswer = relationToCorrectAnswer;
    }

    public short GuessedValue { get; }
    public Relation RelationToCorrectAnswer { get; }
    public bool IsCorrectGuess => RelationToCorrectAnswer == Relation.Correct;

    public override string ToString() {
      return $"Proposing number “{GuessedValue}”... {(IsCorrectGuess ? "correct" : "incorrect")}.";
    }
  }
}