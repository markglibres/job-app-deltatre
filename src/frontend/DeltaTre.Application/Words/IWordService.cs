using System.Threading.Tasks;

namespace DeltaTre.Application.Words
{
    public interface IWordService
    {
        Task<bool> Search(string value);
    }
}