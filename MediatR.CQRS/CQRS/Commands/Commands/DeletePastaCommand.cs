namespace MediatR.CQRS.CQRS.Commands.Commands
{
    public class DeletePastaCommand : IRequest<bool>
    {
        public DeletePastaCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
