using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DeltaTre.Presentation.Api.Words
{
    public class UpdateRequest
    {
        [FromBody]
        public IEnumerable<string> Values { get; set; }
    }
}