using System;
using System.Threading.Tasks;

namespace DeltaTre.Search.Domain.Words.Seedwork
{
    public interface IWordService
    {
        Task<bool> Search(string value);
        Task<Word> Get(Guid id);
        Task IncrementCount(Guid id);
    }
}