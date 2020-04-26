using System.Threading;
using Moq;
using Xunit;

namespace DeltaTre.Search.Application.Tests.WordSearchedEvent
{
    public class WhenIncrementingCount : GivenWordSearchedEventHandler
    {
        public WhenIncrementingCount()
        {
            EventHandler.Handle(Event, CancellationToken.None)
                .Wait();
        }

        [Fact]
        public void Should_Call_IncrementCount_Once()
        {
            MockWordService.Verify(s => s.IncrementCount(Event.WordId), Times.Once);
        }
    }
}