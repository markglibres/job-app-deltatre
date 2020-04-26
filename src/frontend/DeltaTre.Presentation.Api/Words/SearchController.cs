using System.Threading.Tasks;
using DeltaTre.Application.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaTre.Presentation.Api.Words
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{value}")]
        public async Task<IActionResult> Search(SearchWordRequest request)
        {
            var query = new SearchWordQuery
            {
                Value = request.Value
            };

            var response = await _mediator.Send(query);

            var httpResponse = new SearchWordResponse
            {
                Found = response.IsFound,
                Word = response.Value
            };

            return Ok(response);
        }
    }
}