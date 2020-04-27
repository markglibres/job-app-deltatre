using System.Collections.Generic;

namespace DeltaTre.Search.Application.GetTopSearched
{
    public class GetTopSearchedQueryResponse
    {
        public IEnumerable<TopSearchInfo> Results { get; set; }
    }
}