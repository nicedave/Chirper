using Microsoft.Extensions.DependencyInjection;
using System;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CHIRPER!");
            Console.WriteLine();
            Console.WriteLine("ADD USER:\t <user name> registers");
            Console.WriteLine("POSTING:\t <user name> -> <message>");
            Console.WriteLine("READING:\t <user name>");
            Console.WriteLine("FOLLOWING:\t <user name> follows <another user>");
            Console.WriteLine("WALL:\t\t <user name> wall");
            Console.WriteLine();
            Console.WriteLine("NOTE:");
            Console.WriteLine("- <user name>s are not case sentitive");
            Console.WriteLine("- when posting, the <user name> will be added if it does not exist");
            Console.WriteLine();

            ServiceProvider serviceProvider = ServiceProviderBuilder.Build();

            IInputReader inputReader = serviceProvider.GetService<IInputReader>();
            inputReader.ReadInput();
        }
    }
}
