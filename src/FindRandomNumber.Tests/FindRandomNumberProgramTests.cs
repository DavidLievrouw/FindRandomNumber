using System;
using FakeItEasy;
using FindRandomNumber.Generator;
using FindRandomNumber.Guesser;
using NUnit.Framework;

namespace FindRandomNumber {
  [TestFixture]
  public class FindRandomNumberProgramTests {
    IGenerator _generator;
    IGuesser _guesser;
    FindRandomNumberProgram _sut;

    [SetUp]
    public virtual void SetUp() {
      _generator = A.Fake<IGenerator>();
      _guesser = A.Fake<IGuesser>();
      _sut = new FindRandomNumberProgram(_generator, _guesser);
    }

    [TestFixture]
    public class Construction : FindRandomNumberProgramTests {
      [Test]
      public void GivenNullGenerator_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(null, _guesser));
      }

      [Test]
      public void GivenNullGuesser_Throws() {
        Assert.Throws<ArgumentNullException>(() => new FindRandomNumberProgram(_generator, null));
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