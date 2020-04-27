using System.Collections.Generic;
using DeltaTre.Application.Words;

namespace DeltaTre.Application.GetTopSearched
{
    public class GetTopSearchedQueryResponse
    {
        public IEnumerable<WordInfo> Results { get; set; }
    }
}