using Microsoft.AspNetCore.Mvc;

namespace DeltaTre.Presentation.Api.Words
{
    public class GetTopSearchedRequest
    {
        [FromRoute] public int? Top { get; set; }
    }
}