using Microsoft.AspNetCore.Mvc;

namespace DeltaTre.Presentation.Api.Words
{
    public class SearchWordRequest
    {
        [FromRoute] public string Value { get; set; }
    }
}