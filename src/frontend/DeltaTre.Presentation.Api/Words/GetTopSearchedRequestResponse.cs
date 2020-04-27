using System.Collections.Generic;

namespace DeltaTre.Presentation.Api.Words
{
    public class GetTopSearchedRequestResponse
    {
        public IEnumerable<TopSearchedInfo> Results { get; set; }
    }
}