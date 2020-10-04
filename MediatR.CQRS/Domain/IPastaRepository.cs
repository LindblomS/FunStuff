namespace MediatR.CQRS.Domain
{
    using System.Threading.Tasks;

    public interface IPastaRepository
    {
        Task<bool> AddAsync(Pasta pasta);

        Task<bool> DeleteAsync(string name);

        Task<Pasta> FindAsync(string name);
    }
}
