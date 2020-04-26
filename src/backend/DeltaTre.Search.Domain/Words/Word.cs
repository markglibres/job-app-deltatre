using System;
using DeltaTre.Search.Domain.Seedwork;
using DeltaTre.Search.Domain.Words.Events;
using Newtonsoft.Json;

namespace DeltaTre.Search.Domain.Words
{
    public class Word : Entity
    {
        public string Value { get; private set; }
        public int Count { get; private set; }

        [JsonConstructor]
        private Word()
        {
        }

        public Word(string value)
        {
            Value = value;
        }

        public void IncrementCount()
        {
            Count++;
        }

        public void WasSearched()
        {
            Emit(new WordSearchedEvent
            {
                Id = Guid.NewGuid().ToString(),
                WordId = Id
            });
        }
    }
}