using System;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using DeltaTre.Search.Domain.Extensions;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words.Seedwork;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Domain.Words
{
    public class WordService : IWordService
    {
        private readonly ILogger<WordService> _logger;
        private readonly IRepository<Word> _wordRepository;
        private readonly IDomainEventsService _domainEventsService;

        public WordService(
            ILogger<WordService> logger,
            IRepository<Word> wordRepository,
            IDomainEventsService domainEventsService)
        {
            _logger = logger;
            _wordRepository = wordRepository;
            _domainEventsService = domainEventsService;
        }

        public async Task<bool> Search(string value)
        {
            Guard.Against.Empty<WordsException>(value, "word");

            var word = await _wordRepository
                .GetByAsync(w => w.Value.Equals(value, StringComparison.OrdinalIgnoreCase));

            if (word == null) return false;

            word.WasSearched();
            await _domainEventsService.Publish(word.Events, CancellationToken.None);

            return true;

        }
        public async Task<Word> Get(Guid id)
        {
            Guard.Against.Empty<WordsException>(id, "wordId");

            var word = await _wordRepository
                .GetByAsync(w => w.Id.Equals(id));

            return word;
        }

        public async Task IncrementCount(Guid id)
        {
            var word = await Get(id);

            if(word == null) return;

            word.IncrementCount();
            await _wordRepository.SaveAsync(word);

        }
    }
}