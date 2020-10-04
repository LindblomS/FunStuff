namespace MediatR.CQRS.Validation
{
    using FluentValidation;
    using MediatR.CQRS.CQRS.Commands.Commands;

    public class DeletePastaCommandValidator : AbstractValidator<DeletePastaCommand>
    {
        public DeletePastaCommandValidator()
        {
            RuleFor(c => c.Name).NotNull();
        }
    }
}
