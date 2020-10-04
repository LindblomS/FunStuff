namespace MediatR.CQRS.CQRS.Queries
{
    using MediatR.CQRS.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PastaQueries : IPastaQueries
    {
        private readonly IReadOnlyCollection<Pasta> _pastaCollection;

        public PastaQueries(IReadOnlyCollection<Pasta> pastaCollection)
        {
            _pastaCollection = pastaCollection ?? throw new ArgumentNullException(nameof(pastaCollection));
        }

        public async Task<IEnumerable<Pasta>> GetPastaAsync(string name)
        {
            return await Task.Run(() => _pastaCollection.Where(p => p.Name == name));
        }

        public async Task<IEnumerable<Pasta>> GetPastaAsync()
        {
            return await Task.Run(() => _pastaCollection.AsEnumerable());
        }
    }
}
