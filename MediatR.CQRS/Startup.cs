namespace MediatR.CQRS
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using FluentValidation;
    using MediatR.CQRS.AutofacModules;
    using MediatR.CQRS.Behaviours;
    using MediatR.CQRS.CQRS.Commands.Commands;
    using MediatR.CQRS.CQRS.Queries;
    using MediatR.CQRS.Domain;
    using MediatR.CQRS.Repository;
    using MediatR.CQRS.Validation;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Startup
    {
        public Startup()
        {
        }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var context = new List<Pasta>();
            services
                .AddSingleton<IReadOnlyCollection<Pasta>>(sp => context.AsReadOnly())
                .AddSingleton<IList<Pasta>>(sp => context);

            services.AddTransient<IPastaQueries, PastaQueries>();
            services.AddTransient<IPastaRepository, PastaRepository>();

            services.AddTransient<Application>();
            var container = new ContainerBuilder();
            container.RegisterModule(new MediatRModule());
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }
    }
}
