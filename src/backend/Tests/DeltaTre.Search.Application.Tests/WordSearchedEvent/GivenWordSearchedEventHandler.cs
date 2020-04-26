using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using DeltaTre.Search.Application.Events;
using DeltaTre.Search.Domain.Words.Seedwork;
using DeltaTre.Search.Tests.Common;
using Moq;

namespace DeltaTre.Search.Application.Tests.WordSearchedEvent
{
    public abstract class GivenWordSearchedEventHandler
    {
        protected IFixture Fixture { get; }
        protected Mock<IWordService> MockWordService { get; }
        protected WordSearchedEventHandler EventHandler { get; }
        protected Domain.Words.Events.WordSearchedEvent Event { get; }

        public GivenWordSearchedEventHandler()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            MockWordService = Fixture.FreezeMoq<IWordService>();

            EventHandler = Fixture.Create<WordSearchedEventHandler>();

            Event = new Domain.Words.Events.WordSearchedEvent
            {
                Id = Guid.NewGuid().ToString(),
                WordId = Guid.NewGuid()
            };
        }

    }
}