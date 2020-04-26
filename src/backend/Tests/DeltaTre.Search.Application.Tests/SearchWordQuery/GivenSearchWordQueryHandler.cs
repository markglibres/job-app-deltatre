using AutoFixture;
using AutoFixture.AutoMoq;
using DeltaTre.Search.Application.SearchWord;
using DeltaTre.Search.Domain.Words.Seedwork;
using DeltaTre.Search.Tests.Common;
using Moq;

namespace DeltaTre.Search.Application.Tests.SearchWordQuery
{
    public abstract class GivenSearchWordQueryHandler
    {
        public IFixture Fixture { get; }
        public Mock<IWordService> MockWordService { get; }
        public SearchWordQueryHandler QueryHandler { get; }

        public GivenSearchWordQueryHandler()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            MockWordService = Fixture.FreezeMoq<IWordService>();

            QueryHandler = Fixture.Create<SearchWordQueryHandler>();
        }

        
    }
}