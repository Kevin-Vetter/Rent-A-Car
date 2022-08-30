using Microsoft.Extensions.DependencyInjection;
using RentACar.Service.Repository;
using RentACar.Service.Interface;
using System;

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

    static void Menu()
    {
        Console.WriteLine("Welcome to Rent A Car - Car rental service");
    }
}
