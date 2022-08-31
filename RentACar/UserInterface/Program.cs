using Microsoft.Extensions.DependencyInjection;
using RentACar.Service.Repository;
using RentACar.Service.Interface;
using System;
using System.Threading;

namespace RentACar;

public class Program
{
    static void Main()
    {
        #region Dependency injection
        ServiceProvider sp = new ServiceCollection()
            .AddSingleton<IRepository, Repository>()
            .BuildServiceProvider();

        RentACar rentACar = new(sp.GetService<IRepository>());
        #endregion

        Menu();
    }

    #region Menu stuff
    /// <summary>
    /// Prints menu on UI
    /// </summary>
    static void Menu()
    {
        Console.WriteLine("###Welcome to Rent A Car - Car rental service###\n" +
            "1. Rent car \n" +
            "2. Return car \n" +
            "3. New Customer \n" +
            "4. Exit \n");
        OptionHandler();
    }

    static void OptionHandler()
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                break;
            case ConsoleKey.D2:
                break;
            case ConsoleKey.D3:

                break;
            case ConsoleKey.D4:
                Environment.Exit(0);
                break;

            default:
                Console.Clear();
                Menu();
                break;
        }
    }
    #endregion
}
