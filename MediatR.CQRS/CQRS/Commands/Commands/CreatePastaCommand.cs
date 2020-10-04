namespace MediatR.CQRS.CQRS.Commands.Commands
{
    public class CreatePastaCommand : IRequest<bool>
    {
        public CreatePastaCommand(string name, string info)
        {
            Name = name;
            Info = info;
        }

        public string Name { get; }
        public string Info { get; }
    }
}
