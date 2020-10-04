namespace MediatR.CQRS.CQRS.Commands.CommandHandlers
{
    using MediatR.CQRS.CQRS.Commands.Commands;
    using MediatR.CQRS.Domain;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreatePastaCommandHandler : IRequestHandler<CreatePastaCommand, bool>
    {
        private readonly IPastaRepository _pastaRepository;

        public CreatePastaCommandHandler(IPastaRepository pastaRepository)
        {
            _pastaRepository = pastaRepository ?? throw new ArgumentNullException(nameof(pastaRepository));
        }

        public async Task<bool> Handle(CreatePastaCommand request, CancellationToken cancellationToken)
        {
            var pasta = new Pasta(request.Name, request.Info);
            return await _pastaRepository.AddAsync(pasta);
        }
    }
}
