using System.Runtime.CompilerServices;
using DeltaTre.Search.Domain.Seedwork;

namespace DeltaTre.Search.Domain.Words
{
    public class WordsException : DomainException
    {
        public WordsException(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
            : base(FormatMessage(message, memberName, sourceFilePath, sourceLineNumber))
        {
        }
    }
}
