namespace FindRandomNumber.Guesser {
  public struct Guess {
    public Guess(Attempt attempt, Relation relationToCorrectAnswer) {
      Attempt = attempt;
      RelationToCorrectAnswer = relationToCorrectAnswer;
    }

    public Attempt Attempt { get; }
    public Relation RelationToCorrectAnswer { get; }
    public bool IsCorrectGuess => RelationToCorrectAnswer == Relation.Correct;

    public override string ToString() {
      return $"Proposing number “{Attempt.Value}”... {(IsCorrectGuess ? "correct" : "incorrect")}.";
    }
  }
}