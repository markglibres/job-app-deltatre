using System;
using System.Collections.Generic;
using System.Linq;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Infrastructure.Tests.Repository
{
    public class WhenInitializingData : GivenInMemoryWordRepository
    {
        public WhenInitializingData()
        {
            _records = WordRepository.GetAll().Result;
        }

        private readonly IEnumerable<Word> _records;

        [Fact]
        public void Should_Have_Initial_Data()
        {
            _records.Should().NotBeNullOrEmpty();
            _records.Count().Should().Be(InitialData.Count);

            _records.ToList()
                .ForEach(r =>
                    InitialData
                        .Any(d => d.Value.Equals(r.Value, StringComparison.OrdinalIgnoreCase))
                        .Should().BeTrue()
                );
        }
    }
}