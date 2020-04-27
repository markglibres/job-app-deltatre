using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using DeltaTre.Search.Domain.Extensions;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words.Events;
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

        public async Task Create(IEnumerable<string> words)
        {
            var tasks = new List<Task>();

            words
                .ToList()
                .ForEach(w =>
                    {
                        _logger.LogInformation($"creating request for {w}");
                        tasks.Add(
                            _domainEventsService.Publish(
                                new CreateWordRequestedEvent
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Value = w
                                },
                                CancellationToken.None)
                        );
                    }
                    );

            await Task.WhenAll(tasks);
        }

        public async Task<Word> Create(string value)
        {
            var word = await _wordRepository
                .GetByAsync(w => w.Value.Equals(value, StringComparison.OrdinalIgnoreCase));

            if (word != null)
            {
                _logger.LogInformation($"Word {value} has not been created. Already exists.");
                return word;
            }

            word = new Word(value);
            await _wordRepository.InsertAsync(word);

            _logger.LogInformation($"Word {value} has been created.");
            return word;
        }
    }
}