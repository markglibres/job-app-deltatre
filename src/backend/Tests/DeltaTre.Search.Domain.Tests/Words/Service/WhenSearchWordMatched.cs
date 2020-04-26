using System;
using System.Linq.Expressions;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenSearchWordMatched : GivenWordService
    {
        public WhenSearchWordMatched()
        {
            MockRepository.Setup(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()))
                .ReturnsAsync(new Word("test"));

            _result = WordService.Search("test").Result;
        }

        private readonly bool _result;

        [Fact]
        public void Should_Publish_One_Event()
        {
            MockRepository.Verify(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()), Times.Once);
        }

        [Fact]
        public void Should_Return_True()
        {
            _result.Should().BeTrue();
        }
    }
}