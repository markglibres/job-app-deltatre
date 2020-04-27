using MediatR;

namespace DeltaTre.Application.GetTopSearched
{
    public class GetTopSearchedQuery : IRequest<GetTopSearchedQueryResponse>
    {
        public int Top { get; set; }
    }
}