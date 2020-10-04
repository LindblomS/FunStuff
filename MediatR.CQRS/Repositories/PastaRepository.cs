namespace MediatR.CQRS.Repository
{
    using MediatR.CQRS.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PastaRepository : IPastaRepository
    {
        private readonly IList<Pasta> _context;

        public PastaRepository(IList<Pasta> context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(Pasta pasta)
        {
            return await Task.Run(() => 
            {
                try
                {
                    _context.Add(pasta);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(string name)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _context.Remove(_context.Single(p => p.Name == name));
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<Pasta> FindAsync(string name)
        {
            return await Task.Run(() =>
            {
                return _context.SingleOrDefault(p => p.Name == name);
            });
        }
    }
}
