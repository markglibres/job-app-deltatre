using System;
using System.Linq.Expressions;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenSearchWordHasNoMatch : GivenWordService
    {
        public WhenSearchWordHasNoMatch()
        {
            MockRepository.Setup(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()))
                .ReturnsAsync(null as Word);

            _result = WordService.Search("test").Result;
        }

        private readonly bool _result;

        [Fact]
        public void Should_Return_False()
        {
            _result.Should().BeFalse();
        }
    }
}