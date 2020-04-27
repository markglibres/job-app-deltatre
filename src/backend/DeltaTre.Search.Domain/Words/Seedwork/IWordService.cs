using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeltaTre.Search.Domain.Words.Seedwork
{
    public interface IWordService
    {
        Task<bool> Search(string value);
        Task<Word> Get(Guid id);
        Task IncrementCount(Guid id);
        Task Create(IEnumerable<string> words);

        Task<Word> Create(string word);
    }
}