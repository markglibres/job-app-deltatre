using MediatR;

namespace DeltaTre.Search.Application.GetTopSearched
{
    public class GetTopSearchedQuery : IRequest<GetTopSearchedQueryResponse>
    {
        public int Limit { get; set; }
    }
}