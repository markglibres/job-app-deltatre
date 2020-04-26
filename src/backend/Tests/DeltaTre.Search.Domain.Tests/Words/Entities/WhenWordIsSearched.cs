using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words
{
    public class WhenWordIsSearched : GivenWordIsCreated
    {
        public WhenWordIsSearched()
        {
            _currentCount = Word.Count;
            Word.WasSearched();
        }

        private readonly int _currentCount;

        [Fact]
        public void Should_Have_One_Event()
        {
            Word.Events.Should().NotBeEmpty();
            Word.Events.Should().HaveCount(1);
        }

        [Fact]
        public void Should_Have_Untouched_Count()
        {
            Word.Count.Should().Be(_currentCount);
        }
    }
}