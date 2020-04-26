using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using DeltaTre.Search.Domain.Words;
using DeltaTre.Search.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Infrastructure.Tests.Repository
{
    public abstract class GivenInMemoryWordRepository
    {
        protected IFixture Fixture { get; }
        public List<Word> InitialData { get; }
        protected InMemoryWordRepository WordRepository { get; }
        protected GivenInMemoryWordRepository()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            var logger = Fixture.Create<ILogger<InMemoryWordRepository>>();
            InitialData = new List<Word>
            {
                new Word("hello"),
                new Word("goodbye"),
                new Word("simple"),
                new Word("list"),
                new Word("search"),
                new Word("filter"),
                new Word("yes"),
                new Word("no")
            };

            WordRepository = new InMemoryWordRepository(logger, InitialData);
        }

    }
}
