using System.Threading;
using DeltaTre.Search.Application.SearchWord;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Application.Tests.SearchWordQuery
{
    public class WhenWordIsNotFound : GivenSearchWordQueryHandler
    {
        public WhenWordIsNotFound()
        {
            MockWordService.Setup(w => w.Search(It.IsAny<string>()))
                .ReturnsAsync(false);

            _queryRequest = new SearchWord.SearchWordQuery
            {
                Word = "test"
            };

            _result = QueryHandler.Handle(_queryRequest, CancellationToken.None).Result;
        }

        private SearchWord.SearchWordQuery _queryRequest { get; }

        private readonly SearchWordQueryResponse _result;

        [Fact]
        public void Should_Return_Expected_Response()
        {
            _result.Should().NotBeNull();
            _result.IsFound.Should().BeFalse();
            _result.Word.Should().Be(_queryRequest.Word);
        }
    }
}