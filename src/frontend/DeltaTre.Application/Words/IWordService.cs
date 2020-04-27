using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeltaTre.Application.Words
{
    public interface IWordService
    {
        Task<bool> Search(string value);
        Task<bool> Update(IEnumerable<string> values);
        Task<IEnumerable<WordInfo>> GetTopSearched(int limit);
    }
}