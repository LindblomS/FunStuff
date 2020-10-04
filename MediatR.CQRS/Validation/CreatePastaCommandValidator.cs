namespace MediatR.CQRS.Validation
{
    using FluentValidation;
    using MediatR.CQRS.CQRS.Commands.Commands;

    public class CreatePastaCommandValidator : AbstractValidator<CreatePastaCommand>
    {
        public CreatePastaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotEqual("bajs").WithMessage("This is shit");
            RuleFor(c => c.Info).NotEmpty();
        }
    }
}
