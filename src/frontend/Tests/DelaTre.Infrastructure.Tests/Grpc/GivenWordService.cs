using AutoFixture;
using AutoFixture.AutoMoq;
using DeltaTre.Infrastructure.Grpc;
using DeltaTre.Search.Presentation.Rpc;
using DeltaTre.Tests.Common;
using Moq;

namespace DelaTre.Infrastructure.Tests.Grpc
{
    public abstract class GivenWordService
    {
        protected GivenWordService()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            MockWordServiceClient = Fixture.FreezeMoq<WordService.WordServiceClient>();

            WordService = Fixture.Create<GrpcWordService>();
        }

        protected IFixture Fixture { get; }
        protected Mock<WordService.WordServiceClient> MockWordServiceClient { get; }
        protected GrpcWordService WordService { get; }
    }
}