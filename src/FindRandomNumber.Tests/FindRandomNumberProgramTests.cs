using System;
using FakeItEasy;
using FindRandomNumber.Generator;
using NUnit.Framework;

namespace FindRandomNumber {
  [TestFixture]
  public class FindRandomNumberProgramTests {
    IGenerator _generator;
    FindRandomNumberProgram _sut;

    [SetUp]
    public virtual void SetUp() {
      _generator = A.Fake<IGenerator>();
      _sut = new FindRandomNumberProgram(_generator);
    }

    [TestFixture]
    public class Creation : FindRandomNumberProgramTests {
      [Test]
      public void GivenNullGenerator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(null));
      }
    }

    [TestFixture]
    public class Run : FindRandomNumberProgramTests {
      [Test]
      public void GeneratesRandomNumber_UsingGenerator() {
        _sut.Run();
        A.CallTo(() => _generator.Generate()).MustHaveHappened();
      }
    }
  }
}