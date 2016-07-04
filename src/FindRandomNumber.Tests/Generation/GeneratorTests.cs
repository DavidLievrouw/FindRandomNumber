using System;
using FindRandomNumber.Common;
using NUnit.Framework;

namespace FindRandomNumber.Generation {
  [TestFixture]
  public class GeneratorTests {
    Range _range;
    Generation.Generator _sut;

    [SetUp]
    public void SetUp() {
      _range = new Range(100, 10000);
      _sut = new Generation.Generator(_range);
    }

    [TestFixture]
    public class Construction : GeneratorTests {
      [Test]
      public void GivenMaxValueTooLarge_Throws() {
        var invalidRange = new Range(100, short.MaxValue);
        Assert.Throws<ArgumentOutOfRangeException>(() => new Generation.Generator(invalidRange));
      }
    }

    [TestFixture]
    public class Generate : GeneratorTests {
      [Test]
      public void GeneratesRandomNumberBetweenMinAndMax() {
        var actual = _sut.Generate();
        Assert.That(actual.Value, Is.LessThan(_range.Maximum));
        Assert.That(actual.Value, Is.GreaterThan(_range.Minimum));
      }
    }
  }
}