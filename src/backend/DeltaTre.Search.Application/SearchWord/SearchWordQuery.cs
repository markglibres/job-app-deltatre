using MediatR;

namespace DeltaTre.Search.Application.SearchWord
{
    public class SearchWordQuery : IRequest<SearchWordQueryResponse>
    {
        public string Word { get; set; }
    }
}