using System;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Infrastructure.Tests.Repository
{
    public class WhenGettingWord : GivenInMemoryWordRepository
    {
        public WhenGettingWord()
        {
            _wordToSearch = "search";
            _result = WordRepository.GetByAsync(w =>
                    w.Value.Equals(_wordToSearch, StringComparison.OrdinalIgnoreCase))
                .Result;
        }

        private readonly string _wordToSearch;
        private readonly Word _result;

        [Fact]
        public void Should_Match_Value()
        {
            _result.Value.Should().Be(_wordToSearch);
        }

        [Fact]
        public void Should_Not_Be_Null()
        {
            _result.Should().NotBeNull();
        }
    }
}