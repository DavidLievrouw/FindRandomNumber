using System;
using NUnit.Framework;

namespace FindRandomNumber.Common {
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

    [TestFixture]
    public class Equality : RangeTests {
      [Test]
      public void EmptyInstances_AreEqual() {
        var obj1 = new Range();
        var obj2 = new Range();

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
        Assert.That(obj1 == obj2);
      }

      [Test]
      public void ObjectsWithEqualValues_AreEqual() {
        var obj1 = new Range(321, 456);
        var obj2 = new Range(321, 456);

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
      }

      [Test]
      public void ObjectsWithDifferentValues_AreNotEqual() {
        var obj1 = new Range(1, 123);
        var obj2 = new Range(1, 124);
        var obj3 = new Range(0, 123);

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
        Assert.That(!obj2.Equals(obj3));
        Assert.That(obj2 != obj3);
        Assert.That(!obj1.Equals(obj3));
        Assert.That(obj1 != obj3);
      }
    }
  }
}