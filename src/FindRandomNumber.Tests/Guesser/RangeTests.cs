using System;
using NUnit.Framework;

namespace FindRandomNumber.Guesser {
  [TestFixture]
  public class RangeTests {
    [TestFixture]
    public class Construction : RangeTests {
      [Test]
      public void GivenMaximumLessThanMinimum_Throws() {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Range(100, 99));
      }

      [Test]
      public void GivenMaximumEqualToMinimum_DoesNotThrow() {
        var actual = new Range(100, 100);
        Assert.That(actual.Minimum, Is.EqualTo(100));
        Assert.That(actual.Maximum, Is.EqualTo(100));
      }

      [Test]
      public void GivenMaximumGreaterThanMinimum_DoesNotThrow() {
        var actual = new Range(100, 200);
        Assert.That(actual.Minimum, Is.EqualTo(100));
        Assert.That(actual.Maximum, Is.EqualTo(200));
      }
    }
  }
}