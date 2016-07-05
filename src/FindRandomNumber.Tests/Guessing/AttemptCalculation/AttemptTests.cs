using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Guessing.AttemptCalculation {
  [TestFixture]
  public class AttemptTests {
    [TestFixture]
    public class CompareTo : AttemptTests {
      [Test]
      public void GivenValueIsLargerThanAttempt_ReturnsNegativeNumber() {
        var sut = new Attempt(3, default(Range));
        var targetValue = (short)(sut.Value - 1);
        var actual = sut.CompareTo(targetValue);
        Assert.That(actual, Is.LessThan(0));
      }

      [Test]
      public void GivenValueIsSmallerThanAttempt_ReturnsPositiveNumber() {
        var sut = new Attempt(3, default(Range));
        var targetValue = (short)(sut.Value + 1);
        var actual = sut.CompareTo(targetValue);
        Assert.That(actual, Is.GreaterThan(0));
      }

      [Test]
      public void GivenValueIsEqualToAttempt_ReturnsZero() {
        var sut = new Attempt(3, default(Range));
        var targetValue = sut.Value;
        var actual = sut.CompareTo(targetValue);
        Assert.That(actual, Is.Zero);
      }
    }
  }
}