using NUnit.Framework;

namespace FindRandomNumber.Generator {
  [TestFixture]
  public class RandomNumberTests {
    [TestFixture]
    public class Construction : RandomNumberTests {
      short _shortValue;

      [SetUp]
      public void SetUp() {
        _shortValue = 8842;
      }

      [Test]
      public void GivenValidNumber_SetsValue() {
        var sut = new RandomNumber(_shortValue);
        Assert.That(sut.Value, Is.EqualTo(_shortValue));
      }
    }

    [TestFixture]
    public class Equality : RandomNumberTests {
      [Test]
      public void EmptyInstances_AreEqual() {
        var obj1 = new RandomNumber();
        var obj2 = new RandomNumber();

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
        Assert.That(obj1 == obj2);
      }

      [Test]
      public void ObjectsWithEqualValues_AreEqual() {
        var obj1 = new RandomNumber(321);
        var obj2 = new RandomNumber(321);

        Assert.That(obj1.Equals(obj2));
        Assert.That(obj1 == obj2);
        Assert.That(obj1.GetHashCode(), Is.EqualTo(obj2.GetHashCode()));
      }

      [Test]
      public void ObjectsWithDifferentValues_AreNotEqual() {
        var obj1 = new RandomNumber(123);
        var obj2 = new RandomNumber(124);
        var obj3 = new RandomNumber(0);

        Assert.That(!obj1.Equals(obj2));
        Assert.That(obj1 != obj2);
        Assert.That(!obj2.Equals(obj3));
        Assert.That(obj2 != obj3);
        Assert.That(!obj1.Equals(obj3));
        Assert.That(obj1 != obj3);
      }

      [Test]
      public void WhenValueIsEqualToShort_AreEqual() {
        var obj1 = new RandomNumber(321);
        short obj2 = 321;
        Assert.That(obj1 == obj2);
      }

      [Test]
      public void WhenValueIsNotEqualToShort_AreNotEqual() {
        var obj1 = new RandomNumber(321);
        short obj2 = 322;
        Assert.That(obj1 != obj2);
      }
    }

    [TestFixture]
    public class LargerThanOrEqualTo : RandomNumberTests {
      [TestCase(123, 123, true)]
      [TestCase(123, 124, false)]
      [TestCase(123, 122, true)]
      public void CanCompareRandomNumbers(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        var obj2 = new RandomNumber(value2);
        Assert.That(obj1 >= obj2, Is.EqualTo(expectedResult));
      }

      [TestCase(123, 123, true)]
      [TestCase(123, 124, false)]
      [TestCase(123, 122, true)]
      public void CanCompareToShortValue(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        Assert.That(obj1 >= value2, Is.EqualTo(expectedResult));
      }
    }

    [TestFixture]
    public class LargerThan : RandomNumberTests {
      [TestCase(123, 123, false)]
      [TestCase(123, 124, false)]
      [TestCase(123, 122, true)]
      public void CanCompareRandomNumbers(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        var obj2 = new RandomNumber(value2);
        Assert.That(obj1 > obj2, Is.EqualTo(expectedResult));
      }

      [TestCase(123, 123, false)]
      [TestCase(123, 124, false)]
      [TestCase(123, 122, true)]
      public void CanCompareToShortValue(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        Assert.That(obj1 > value2, Is.EqualTo(expectedResult));
      }
    }

    [TestFixture]
    public class LessThanOrEqualTo : RandomNumberTests {
      [TestCase(123, 123, true)]
      [TestCase(123, 124, true)]
      [TestCase(123, 122, false)]
      public void CanCompareRandomNumbers(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        var obj2 = new RandomNumber(value2);
        Assert.That(obj1 <= obj2, Is.EqualTo(expectedResult));
      }

      [TestCase(123, 123, true)]
      [TestCase(123, 124, true)]
      [TestCase(123, 122, false)]
      public void CanCompareToShortValue(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        Assert.That(obj1 <= value2, Is.EqualTo(expectedResult));
      }
    }

    [TestFixture]
    public class LessThan : RandomNumberTests {
      [TestCase(123, 123, false)]
      [TestCase(123, 124, true)]
      [TestCase(123, 122, false)]
      public void CanCompareRandomNumbers(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        var obj2 = new RandomNumber(value2);
        Assert.That(obj1 < obj2, Is.EqualTo(expectedResult));
      }

      [TestCase(123, 123, false)]
      [TestCase(123, 124, true)]
      [TestCase(123, 122, false)]
      public void CanCompareToShortValue(short value1, short value2, bool expectedResult) {
        var obj1 = new RandomNumber(value1);
        Assert.That(obj1 < value2, Is.EqualTo(expectedResult));
      }
    }

    [TestFixture]
    public class ToStringOverride : RandomNumberTests {
      short _value;
      RandomNumber _sut;

      [SetUp]
      public void SetUp() {
        _value = 1224;
        _sut = new RandomNumber(_value);
      }

      [Test]
      public void ToStringReturnsShortValueAsString() {
        var actual = _sut.ToString();
        Assert.That(actual, Is.EqualTo(_value.ToString()));
      }
    }

    [TestFixture]
    public class ConversionOperatorFromShort : RandomNumberTests {
      [Test]
      public void CreatesRandomNumberWithExpectedValue() {
        var shortValue = 7824;
        var sut = (RandomNumber)shortValue;
        Assert.That(sut.Value, Is.EqualTo(shortValue));
      }
    }

    [TestFixture]
    public class ConversionOperatorToShort : RandomNumberTests {
      [Test]
      public void ReturnsValueOfRandomNumber() {
        short shortValue = 7824;
        var sut = new RandomNumber(shortValue);
        short actual = sut;
        Assert.That(actual, Is.EqualTo(shortValue));
      }
    }
  }
}