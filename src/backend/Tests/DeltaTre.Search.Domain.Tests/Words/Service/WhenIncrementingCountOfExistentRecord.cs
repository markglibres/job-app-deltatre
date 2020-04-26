using System;
using System.Linq.Expressions;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenIncrementingCountOfExistentRecord : GivenWordService
    {
        public WhenIncrementingCountOfExistentRecord()
        {
            _word = new Word("test");
            MockRepository.Setup(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()))
                .ReturnsAsync(_word);

            WordService.IncrementCount(_word.Id).Wait();
        }

        private readonly Word _word;

        [Fact]
        public void Should_Call_SaveAsync()
        {
            MockRepository.Verify(r => r.SaveAsync(It.IsAny<Word>()), Times.Once);
        }

        [Fact]
        public void Should_Increment_Count()
        {
            _word.Count.Should().Be(1);
        }
    }
}