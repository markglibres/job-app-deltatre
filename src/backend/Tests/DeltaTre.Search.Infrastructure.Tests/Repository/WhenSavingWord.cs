using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Infrastructure.Tests.Repository
{
    public class WhenSavingWord : GivenInMemoryWordRepository
    {
        public WhenSavingWord()
        {
            _wordToUpdate = "filter";
            var word = WordRepository
                .GetByAsync(w => w.Value.Equals(_wordToUpdate))
                .Result;

            _initialCount = word.Count;
            word.IncrementCount();
            WordRepository.SaveAsync(word).Wait();
        }

        private readonly string _wordToUpdate;
        private readonly int _initialCount;

        [Fact]
        public void Should_Have_Updated_Value()
        {
            var word = WordRepository
                .GetByAsync(w => w.Value.Equals(_wordToUpdate))
                .Result;

            word.Count.Should().Be(_initialCount + 1);
        }
    }
}