using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words
{
    public class WhenCreatingWord : GivenWordIsCreated
    {
        [Fact]
        public void Should_Get_Correct_String_Value()
        {
            Word.Should().NotBeNull();
            Word.Value.Should().Be(WordValue);
        }

        [Fact]
        public void Should_Have_0_Count()
        {
            Word.Count.Should().Be(0);
        }

        [Fact]
        public void Should_Have_No_Events()
        {
            Word.Events.Should().BeEmpty();
        }
    }
}