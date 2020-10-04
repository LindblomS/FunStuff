namespace MediatR.CQRS.CQRS.Queries
{
    using MediatR.CQRS.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPastaQueries
    {
        Task<IEnumerable<Pasta>> GetPastaAsync(string name);
        Task<IEnumerable<Pasta>> GetPastaAsync();
    }
}
