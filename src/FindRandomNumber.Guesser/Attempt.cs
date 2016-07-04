namespace FindRandomNumber.Guesser {
  public struct Attempt {
    public Attempt(short value, Range range) {
      Value = value;
      Range = range;
    }

    public short Value { get; }
    public Range Range { get; }
  }
}
