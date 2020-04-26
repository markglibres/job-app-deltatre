using System.Threading.Tasks;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Infrastructure.Tests.Repository
{
    public class WhenInsertingNewWord : GivenInMemoryWordRepository
    {
        public WhenInsertingNewWord()
        {
            Word = new Word("fishing");
            WordRepository.InsertAsync(Word).Wait();
        }

        private Word Word { get; }

        [Fact]
        public async Task Should_Get_Same_Item()
        {
            var _result = await WordRepository.GetByAsync(w => w.Id.Equals(Word.Id));
            _result.Should().NotBeNull();
            _result.Should().Be(Word);
        }
    }
}