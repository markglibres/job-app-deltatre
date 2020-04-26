using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words
{
    public class WhenCountIsIncrementedMultiple : GivenWordIsCreated
    {
        public WhenCountIsIncrementedMultiple()
        {
            for (var i = 0; i < IncrementCount; i++) Word.IncrementCount();
        }

        private const int IncrementCount = 3;

        [Fact]
        public void Should_Have_Count_Multiple()
        {
            Word.Count.Should().Be(IncrementCount);
        }

        [Fact]
        public void Should_Have_No_Events()
        {
            Word.Events.Should().BeEmpty();
        }
    }
}