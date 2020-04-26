using DeltaTre.Application.SearchWord;
using MediatR;

namespace DeltaTre.Application.Search
{
    public class SearchWordQuery : IRequest<SearchWordQueryResponse>
    {
        public string Value { get; set; }
    }
}