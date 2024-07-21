using FluentAssertions;
using NikEp.Auth.Domain.ValueObjects;


namespace NikEp.Auth.Domain.UnitTests.ValueObjects
{


    public class NameTests
    {
        [Theory]
        [TestCase(null, false)]
        public void Create_(string? value, bool expectedSucsess)
        {
            // Arrange
            //Act
            var (isSucsess, _, _) = Name.Create(value!);
            //Assert
            isSucsess.Should().Be(expectedSucsess);
            Assert.That(isSucsess, Is.EqualTo(expectedSucsess));
        }
    }
}