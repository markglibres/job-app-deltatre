using System;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenSearchWordIsNullOrEmpty : GivenWordService
    {
        public Func<Task<bool>> Act { get; }
        public WhenSearchWordIsNullOrEmpty()
        {
            Act = () => WordService.Search(string.Empty);
        }

        [Fact]
        public void Should_Throw_Domain_Exception()
        {
            Act.Should().ThrowAsync<WordsException>()
                .WithMessage("word cannot be null or empty");
        }
    }
}