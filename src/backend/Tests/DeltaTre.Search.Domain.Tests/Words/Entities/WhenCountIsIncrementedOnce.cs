using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words
{
    public class WhenCountIsIncrementedOnce : GivenWordIsCreated
    {
        public WhenCountIsIncrementedOnce()
        {
            Word.IncrementCount();
        }

        [Fact]
        public void Should_Have_Count_One()
        {
            Word.Count.Should().Be(1);
        }

        [Fact]
        public void Should_Have_No_Events()
        {
            Word.Events.Should().BeEmpty();
        }
    }
}