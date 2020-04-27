using System.Collections.Generic;
using MediatR;

namespace DeltaTre.Application.UpdateWords
{
    public class UpdateWordsCommand : IRequest<UpdateWordsCommandResponse>
    {
        public IEnumerable<string> Values { get; set; }
    }
}