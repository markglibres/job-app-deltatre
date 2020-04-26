using System;
using System.Linq.Expressions;
using DeltaTre.Search.Domain.Words;
using FluentAssertions;
using Moq;
using Xunit;

namespace DeltaTre.Search.Domain.Tests.Words.Service
{
    public class WhenIncrementingCountOfNonExistentRecord : GivenWordService
    {
        public WhenIncrementingCountOfNonExistentRecord()
        {
            MockRepository.Setup(r => r.GetByAsync(It.IsAny<Expression<Func<Word, bool>>>()))
                .ReturnsAsync(null as Word);

            WordService.IncrementCount(Guid.NewGuid()).Wait();
        }

        [Fact]
        public void Should_Not_Call_SaveAsync()
        {
            MockRepository.Verify(r => r.SaveAsync(It.IsAny<Word>()), Times.Never);
        }

    }
}