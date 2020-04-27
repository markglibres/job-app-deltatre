using System.Linq;
using System.Threading.Tasks;
using DeltaTre.Application.GetTopSearched;
using DeltaTre.Application.UpdateWords;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Presentation.Api.Words
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ILogger<WordsController> _logger;
        private readonly IMediator _mediator;

        public WordsController(
            ILogger<WordsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateRequest request)
        {
            var command = new UpdateWordsCommand
            {
                Values = request.Values
            };

            var response = await _mediator.Send(command);

            return Ok(new UpdateRequestResponse
            {
                Success = response.Success
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetTopSearched()
        {
            var query = new GetTopSearchedQuery
            {
                Top = 5
            };

            var response = await _mediator.Send(query);

            return Ok(new GetTopSearchedRequestResponse
            {
                Results = response
                    .Results
                    .ToList()
                    .Select(r => new TopSearchedInfo
                    {
                        Count = r.Count,
                        Value = r.Value
                    })
            });
        }
    }
}