using FluentAssertions;
using NikEp.Auth.Domain.ValueObjects;

namespace NikEp.Auth.Domain.UnitTests.ValueObjects
{
    public class NameTests
    {
        [Test]
        public void Create_HappyPath()
        {
            var name = new Name("sdfsdf");

            //Assert
            name.Value.Should().Be("sdfsdf");
        }

        [Test]
        public void Create_SmokeTest()
        {
            var _ = new Name("sdfsdf");
        }
        
        [Theory]
        [TestCase("d`Artanyan de xlcj")]
        [TestCase("Ивин")]
        [TestCase("__nagibatior__")]
        public void Create_StrangeNames_Success(string value)
        {
            var name = new Name(value);

            name.Value.Should().Be(value);
        }
        
        [Theory]
        [TestCase("Ив ан", "Ив ан")]
        [TestCase(" Иван",  "Иван")]
        public void Create_Transformation_Success(string value, string expectedValue)
        {
            // Arrange
            //Act
            var (isSucsess, _, result) = Name.Create(value!);
            //Assert
            isSucsess.Should().Be(true);
            result.Value.Should().Be(value);
        }
        
        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")] 
        public void Create_InvalidName_Fail(string? value)
        {
            var act = () => new Name(value!);

            act.Should().Throw<ArgumentException>();
        }
    }
}