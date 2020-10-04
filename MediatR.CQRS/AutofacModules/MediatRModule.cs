using Autofac;
using FluentValidation;
using MediatR.CQRS.Behaviours;
using System.Linq;
using System.Reflection;

namespace MediatR.CQRS.AutofacModules
{
    public class MediatRModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            // Resgiter all command handlers
            builder.RegisterAssemblyTypes(typeof(Startup).GetTypeInfo().Assembly).AsClosedTypesOf(typeof(IRequestHandler<,>));

            // Validators
            builder.RegisterAssemblyTypes(typeof(Startup).GetTypeInfo().Assembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();

            // Standard mediatR registration
            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            // Pipeline behaviours
            builder.RegisterGeneric(typeof(ValidatorBehaviour<,>)).As(typeof(IPipelineBehavior<,>));

        }
    }
}
