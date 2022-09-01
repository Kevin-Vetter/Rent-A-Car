using Microsoft.Extensions.DependencyInjection;
using RentACar.Service.Repository;
using RentACar.Service.Interface;
using System;

namespace RentACar;

public class Program
{
    static void Main()
    {
        Menu();
    }

    #region Menu stuff
    /// <summary>
    /// Prints menu on UI
    /// </summary>
    static void Menu()
    {
        #region Dependency injection
        ServiceProvider sp = new ServiceCollection()
            .AddSingleton<IRepository, Repository>()
            .BuildServiceProvider();

        RentACar rentACar = new(sp.GetService<IRepository>());
        #endregion

        Console.WriteLine("###Welcome to Rent A Car - Car rental service###\n" +
            "1. Rent car \n" +
            "2. Return car \n" +
            "3. New Customer \n" +
            "4. Exit \n");
        OptionHandler(rentACar);
    }

    static void OptionHandler(RentACar rentACar)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:

                break;
            case ConsoleKey.D2:
                rentACar.irepository.RentCar();
                break;
            case ConsoleKey.D3:
                var customer = rentACar.irepository.CreateCustomer(ValidateName(), ValidateAge());

                Console.WriteLine($"New customer has been created\n" +
                    $"Name: {customer.Name}\n" +
                    $"Age: {customer.Age}\n" +
                    $"Id: {customer.Id}");
                Continue();
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

    #region Validation stuff
    static string ValidateName()
    {
        bool trueName = false;
        string? name = string.Empty;
        while (!trueName)
        {
            Console.WriteLine("Type your name:");
            name = Console.ReadLine();

            if (!string.IsNullOrEmpty(name.Trim()))
                trueName = true;
            Console.Clear();
        }
        return name;
    }
    static int ValidateAge()
    {
        bool CorrectInt = false;
        int age = 0;

        while (!CorrectInt)
        {
            Console.WriteLine("Type your age: ");
         CorrectInt = int.TryParse(Console.ReadLine(), out age);
            if (age < 18)
                CorrectInt = false;
            Console.Clear();
        }
        
        return age;
    }
    static void Continue()
    {
        Console.WriteLine("\nPress any key to continue");
        Console.ReadKey();
    }
    #endregion
}
