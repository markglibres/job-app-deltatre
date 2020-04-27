using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeltaTre.Application.Words;
using DeltaTre.Search.Presentation.Rpc;
using Microsoft.Extensions.Logging;
using WordInfo = DeltaTre.Application.Words.WordInfo;

namespace DeltaTre.Infrastructure.Grpc
{
    public class GrpcWordService : IWordService
    {
        private readonly ILogger<GrpcWordService> _logger;
        private readonly WordService.WordServiceClient _wordServiceClient;

        public GrpcWordService(
            ILogger<GrpcWordService> logger,
            WordService.WordServiceClient wordServiceClient)
        {
            _logger = logger;
            _wordServiceClient = wordServiceClient;
        }

        public async Task<bool> Search(string value)
        {
            _logger.LogInformation($"searching {value} with grpc");
            var reply = await _wordServiceClient.FindAsync(new SearchRequest
            {
                Word = value
            });

            return reply.Found;
        }

        public async Task<bool> Update(IEnumerable<string> values)
        {
            var listToAdd = values.ToList();

            _logger.LogInformation($"updating list with {string.Join(", ", listToAdd)}");

            var request = new UpdateRequest();
            request.Word.AddRange(listToAdd);

            var reply = await _wordServiceClient.UpdateAsync(request);
            return reply.Success;
        }

        public async Task<IEnumerable<WordInfo>> GetTopSearched(int limit)
        {
            _logger.LogInformation($"retrievig top {limit} searched words");

            var request = new GetTopRequests
            {
                Top = limit
            };

            var reply = await _wordServiceClient.GetTopWordsAsync(request);

            var response = reply.Results.Select(r => new WordInfo
            {
                Count = r.Count,
                Value = r.Value
            });

            return response;
        }
    }
}