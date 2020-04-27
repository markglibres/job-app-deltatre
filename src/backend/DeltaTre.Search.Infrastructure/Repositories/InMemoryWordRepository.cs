using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words;
using Microsoft.Extensions.Logging;

namespace DeltaTre.Search.Infrastructure.Repositories
{
    public class InMemoryWordRepository : IRepository<Word>
    {
        private readonly ILogger<InMemoryWordRepository> _logger;
        private IQueryable<Word> _wordRecords;

        public InMemoryWordRepository(
            ILogger<InMemoryWordRepository> logger,
            IEnumerable<Word> defaultValues)
        {
            _logger = logger;
            _wordRecords = defaultValues.AsQueryable();
        }

        public Task InsertAsync(Word entity)
        {
            var records = _wordRecords.ToList();
            records.Add(entity);

            _wordRecords = records.AsQueryable();
            return Task.CompletedTask;
        }

        public Task SaveAsync(Word entity)
        {
            var word = _wordRecords.FirstOrDefault(w => w.Id.Equals(entity.Id));
            if (word == null) return Task.CompletedTask;

            var records = _wordRecords.ToList();
            records.Remove(word);
            records.Add(entity);

            return Task.CompletedTask;
        }

        public Task<Word> GetByAsync(Expression<Func<Word, bool>> filter)
        {
            var response = _wordRecords
                .FirstOrDefault(filter);
            return Task.FromResult(response);
        }
        public Task<IEnumerable<Word>> GetAll()
        {
            var records = _wordRecords.AsEnumerable();
            return Task.FromResult(records);
        }

        public Task<IEnumerable<Word>> GetAsync(Func<IQueryable<Word>, IQueryable<Word>> filter)
        {
            var response = filter(_wordRecords);
            return Task.FromResult(response.AsEnumerable());
        }
    }

}