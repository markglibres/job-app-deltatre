using System;
using System.Linq.Expressions;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenGettingWordInfo : GivenWordService
    {
        private readonly Word _word;
        private readonly Word _result;
        public WhenGettingWordInfo()
        {
            _word = new Word("test");
            MockRepository.Setup(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()))
                .ReturnsAsync(_word);

            _result = WordService.Get(_word.Id).Result;
        }
      
        [Fact]
        public void Should_Match_Object_Properties()
        {
            _result.Value.Should().Be(_word.Value);
            _result.Id.Should().Be(_word.Id);
        }

        [Fact]
        public void Should_Not_Null_Response()
        {
            _result.Should().NotBeNull();
        }
    }
}