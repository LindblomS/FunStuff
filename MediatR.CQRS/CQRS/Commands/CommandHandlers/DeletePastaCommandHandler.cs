namespace MediatR.CQRS.CQRS.Commands.CommandHandlers
{
    using MediatR.CQRS.CQRS.Commands.Commands;
    using MediatR.CQRS.Domain;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeletePastaCommandHandler : IRequestHandler<DeletePastaCommand, bool>
    {
        private readonly IPastaRepository _pastaRepository;

        public DeletePastaCommandHandler(IPastaRepository pastaRepository)
        {
            _pastaRepository = pastaRepository ?? throw new ArgumentNullException(nameof(pastaRepository));
        }

        public async Task<bool> Handle(DeletePastaCommand request, CancellationToken cancellationToken)
        {
            return await _pastaRepository.DeleteAsync(request.Name);
        }
    }
}
