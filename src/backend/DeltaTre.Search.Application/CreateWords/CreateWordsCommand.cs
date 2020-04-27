using System.Collections.Generic;
using MediatR;

namespace DeltaTre.Search.Application.CreateWords
{
    public class CreateWordsCommand : IRequest<CreateWordsCommandResponse>
    {
        public IEnumerable<string> Values { get; set; }
    }
}