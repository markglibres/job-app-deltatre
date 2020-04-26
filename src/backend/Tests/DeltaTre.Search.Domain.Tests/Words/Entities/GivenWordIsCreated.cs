using DeltaTre.Search.Domain.Words;

namespace DeltaTre.Search.Domain.Tests.Words
{
    public abstract class GivenWordIsCreated
    {
        protected const string WordValue = "MyWord";

        protected GivenWordIsCreated()
        {
            Word = new Word(WordValue);
        }

        protected Word Word { get; set; }
    }
}