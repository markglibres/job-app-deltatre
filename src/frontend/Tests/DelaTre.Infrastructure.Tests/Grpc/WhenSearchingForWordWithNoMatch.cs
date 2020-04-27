using System.Threading.Tasks;
using DeltaTre.Search.Presentation.Rpc;
using FluentAssertions;
using Grpc.Core;
using Moq;
using Xunit;

namespace DelaTre.Infrastructure.Tests.Grpc
{
    public class WhenSearchingForWordWithNoMatch : GivenWordService
    {
        public WhenSearchingForWordWithNoMatch()
        {
            MockWordServiceClient.Setup(c =>
                    c.FindAsync(
                        It.IsAny<SearchRequest>(),
                        null, null, default))
                .Returns(ValueFunction);

            _result = WordService.Search("test").Result;
        }

        private readonly bool _result;

        private AsyncUnaryCall<SearchResponse> ValueFunction()
        {
            var response = new AsyncUnaryCall<SearchResponse>(
                FakeResponse(),
                Task.FromResult(default(Metadata)),
                () => Status.DefaultSuccess,
                () => Metadata.Empty,
                delegate { });

            return response;
        }

        private Task<SearchResponse> FakeResponse()
        {
            return Task.FromResult(new SearchResponse
            {
                Found = false,
                Word = "test"
            });
        }

        [Fact]
        public void Should_Return_True()
        {
            _result.Should().BeFalse();
        }
    }
}