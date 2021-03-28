using Microsoft.Extensions.DependencyInjection;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public static class ServiceProviderBuilder
    {

        public static ServiceProvider Build()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IInputReader, ConsoleInputReader>()
                .AddSingleton<IDateFormatter, TimePassedDateFormatter>()
                .AddSingleton<IOutputPrinter, ConsoleOutputPrinter>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IChirperContext, FakeChirperContext>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
