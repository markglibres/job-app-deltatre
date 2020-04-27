using Microsoft.AspNetCore.Mvc;

namespace DeltaTre.Presentation.Api.Search
{
    public class SearchWordRequest
    {
        [FromRoute] public string Value { get; set; }
    }
}