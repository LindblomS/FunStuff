namespace MediatR.CQRS.Behaviours
{
    using FluentValidation;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidatorBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehaviour(IValidator<TRequest>[] validators)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                Console.WriteLine($"Validation for command {typeof(TRequest).Name} failed", new ValidationException("Validation exceptions", failures));
                return await Task.Run(() => { return default(TResponse); });
            }

            return await next();
        }
    }
}
