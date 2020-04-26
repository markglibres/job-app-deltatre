using System.Threading.Tasks;
using DeltaTre.Application.Words;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Infrastructure.Services
{
    public class GrpcWordService : IWordService
    {
        private readonly ILogger<GrpcWordService> _logger;

        public GrpcWordService(ILogger<GrpcWordService> logger)
        {
            _logger = logger;
        }

        public async Task<bool> Search(string value)
        {
            _logger.LogInformation($"searching {value} with grpc");
            return true;
        }
    }
}