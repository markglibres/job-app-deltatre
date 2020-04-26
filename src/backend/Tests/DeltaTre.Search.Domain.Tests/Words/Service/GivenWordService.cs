using AutoFixture;
using AutoFixture.AutoMoq;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words;
using DeltaTre.Search.Tests.Common;
using Moq;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public abstract class GivenWordService
    {
        protected IFixture Fixture { get; }
        protected Mock<IRepository<Word>> MockRepository { get; }
        protected Mock<IDomainEventsService> MockDomainEventsService { get; }
        protected WordService WordService { get; }

        protected GivenWordService()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            MockRepository = Fixture.FreezeMoq<IRepository<Word>>();
            MockDomainEventsService = Fixture.FreezeMoq<IDomainEventsService>();
            WordService = Fixture.Create<WordService>();
        }

        
    }
}