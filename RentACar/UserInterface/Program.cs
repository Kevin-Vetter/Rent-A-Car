using Microsoft.Extensions.DependencyInjection;
using RentACar.Service.Repository;
using RentACar.Service.Interface;
using System.Collections.Generic;
using System;

namespace RentACar;

public class Program
{
    static void Main()
    {
        //TODO: Summary all over the place, thew new stfu, test (TEST ON FINES!!!! [BRILLIANT])? X(
        Menu();
        Console.Clear();
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
            "3. New car \n" +
            "4. New customer \n" +
            "5. Exit \n");
        OptionHandler(rentACar);
    }

    static void OptionHandler(RentACar rentACar)
    {
        switch (Console.ReadKey(true).Key)
        {
            #region Rent car
            case ConsoleKey.D1:
                //TODO: Only do if KM < 200K
                Console.WriteLine("Choose car:");
                List<string[]> carStrings = rentACar.irepository.GetAllCars();
                Console.WriteLine("ID \tBrand \tModel \tColor \tPrice \tKM\n");
                foreach (string[] s in carStrings)
                {
                    Console.Write($"{s[0]}. \t");
                    Console.Write($"{s[1]} \t");
                    Console.Write($"{s[2]} \t");
                    Console.Write($"{s[3]} \t");
                    Console.Write($"${s[4]} \t");
                    Console.Write($"{s[5]} \t");
                    if (s[6] == "False")
                        Console.Write($"In store: {s[6]} - Returned by {s[7]} \n");
                    else
                        Console.Write($"In store: {s[6]}\n");
                }
                int id;
                Console.WriteLine();
                while (true)
                {
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out id) && !rentACar.irepository.CarInStore(id))
                    {
                        //TODO: Reserve to customer id
                        break;
                    }
                    else if (rentACar.irepository.CarInStore(id))
                    {
                        //TODO: RentedCarID to Car Id Car.ReturnDate = DateTime.Today + 1week
                    }
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                    Console.Write("".PadRight(Console.WindowWidth));
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                }
                rentACar.irepository.RentCar(id);
                Continue();
                break;
            #endregion

            #region Return
            case ConsoleKey.D2:
                //TODO: ADD KM
                //TODO: everything return, carwash (async? - ChrThy), bon
                //TODO: fined for late return
                throw new NotImplementedException();
                break;
            #endregion

            #region New car
            case ConsoleKey.D3:
                Console.Clear();
                string[] carTraits = CarTraitsValidation();
                rentACar.irepository.CreateNewCar(carTraits[0],
                    carTraits[1],
                    carTraits[2],
                    carTraits[3],
                    carTraits[4],
                    Convert.ToBoolean(carTraits[5]),
                    Convert.ToDateTime(carTraits[6]));
                break;
            #endregion

            #region New customer
            case ConsoleKey.D4:
                Console.Clear();

                var customer = rentACar.irepository.CreateCustomer(ValidateName(), ValidateAge());

                Console.WriteLine($"New customer has been created\n" +
                    $"Name: {customer.Name}\n" +
                    $"Age: {customer.Age}\n" +
                    $"Id: {customer.Id}");
                Continue();
                break;
            #endregion


            case ConsoleKey.D5:
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
    static string[] CarTraitsValidation()
    {
        string returnDate = string.Empty;
        string brand = string.Empty;
        string model = string.Empty;
        string color = string.Empty;
        string price = string.Empty;
        string home = string.Empty;
        string km = string.Empty;

        bool satisfied = false;
        while (!satisfied)
        {
            Console.Write("Brand: ");
            brand = Console.ReadLine();
            Console.Write("Model: ");
            model = Console.ReadLine();
            Console.Write("Color: ");
            color = Console.ReadLine();


            Console.Write("Price: $");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    price = result.ToString();
                    break;
                }
                Console.SetCursorPosition(0, 3);
                Console.Write("Price: $".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(8, 3);
            }

            Console.Write("Kilometers: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int kilometers) && kilometers < 200000)
                {
                    km = kilometers.ToString();
                    break;
                }
                Console.SetCursorPosition(0, 4);
                Console.Write("Kilometers: ".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(12, 4);
            }


            Console.Write("In store: ");
            while (true)
            {
                home = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(home) && home.ToLower() == "true")
                {
                    home = "true";
                    returnDate = "01/01/01";
                    break;
                }
                else if (home.ToLower() == "false")
                {
                    home = "false";
                    DateTime result;

                    while (true)
                    {
                        Console.Write("Return Date: ");

                        if (DateTime.TryParse(Console.ReadLine(), out result) && result >= DateTime.Today)
                        {
                            break;
                        }
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                            Console.Write("Return Date: ".PadRight(Console.WindowWidth));
                            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
                    }
                    returnDate = result.ToShortDateString();


                    break;
                }
                else
                {
                    Console.SetCursorPosition(0, 5);
                    Console.Write("In store: ".PadRight(Console.WindowWidth));
                    Console.SetCursorPosition(10, 5);
                }
            }

            Console.WriteLine($"\n\nDo you wish to create car: " +
                $"{brand} - " +
                $"{model} - " +
                $"{color}, " +
                $"{km}km, " +
                $"${price}" +
                $"\nIn store: {home}?" +
                $"\nReturn date: {returnDate}");

            Console.WriteLine("Y/N");
            while (!satisfied)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Y)
                {
                    satisfied = true;
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    Console.Clear();
                    break;
                }
            }
        }


        return new string[] { brand, model, color, km, price, home, returnDate };
    }
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
