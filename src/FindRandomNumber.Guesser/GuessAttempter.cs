﻿using FindRandomNumber.Guesser.AttemptCalculation;

namespace FindRandomNumber.Guesser {
  public class GuessAttempter : IGuessAttempter {
    readonly short _valueToGuess;

    public GuessAttempter(short valueToGuess) {
      _valueToGuess = valueToGuess;
    }

    public Guess AttemptGuess(Attempt attempt) {
      var relation = attempt.Value == _valueToGuess
        ? RelationToTargetValue.Correct
        : attempt.Value < _valueToGuess
          ? RelationToTargetValue.LessThanTargetValue
          : RelationToTargetValue.GreaterThanTargetValue;

      return new Guess(attempt, relation);
    }
  }
}