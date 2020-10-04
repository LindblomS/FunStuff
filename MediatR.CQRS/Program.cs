namespace MediatR.CQRS
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices(services);
            var app = serviceProvider.GetService<Application>();

            var task = Task.Run(() => app.DoStuff());
            task.Wait();
        }
    }
}
