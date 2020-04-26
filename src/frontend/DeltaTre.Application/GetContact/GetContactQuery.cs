using System;
using MediatR;

namespace DeltaTre.Application.GetContact
{
    public class GetContactQuery : IRequest<GetContactQueryResponse>
    {
        public Guid ContactId { get; set; }
    }
}