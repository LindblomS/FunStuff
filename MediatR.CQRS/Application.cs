namespace MediatR.CQRS
{
    using MediatR.CQRS.CQRS.Commands.Commands;
    using MediatR.CQRS.CQRS.Queries;
    using System;
    using System.Threading.Tasks;

    public class Application
    {
        private readonly IMediator _mediator;
        private readonly IPastaQueries _queries;

        public Application(IMediator mediator, IPastaQueries queries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        public async Task DoStuff()
        {
            var createPastaCommand = new CreatePastaCommand("Rigatoni", "tube shaped pasta kind of");
            await _mediator.Send(createPastaCommand);
            createPastaCommand = new CreatePastaCommand("bajs", "hmmm");
            await _mediator.Send(createPastaCommand);

            foreach (var pasta in await _queries.GetPastaAsync())
            {
                Console.WriteLine($"{pasta.Name}, {pasta.Info}");
            }

            Console.ReadKey();
        }
    }
}
