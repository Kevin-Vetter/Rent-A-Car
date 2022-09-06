﻿using RentACar.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RentACar.DAL
{
    public class Stream
    {
        private static string _carPath = @"C:\Users\kevin\source\repos\RentACar\RentACar\Database\Cars.csv";
        private static string _customerPath = @"C:\Users\Kevin\source\repos\RentACar\RentACar\Database\Customers.csv";

        static public void SaveCar(Car car)
        {
            using (TextWriter writer = new StreamWriter(_carPath, true))
            {
                writer.WriteLine($"{car.Id};" +
                    $"{car.Brand};" +
                    $"{car.Model};" +
                    $"{car.Color};" +
                    $"{car.Km};" +
                    $"{car.Price};" +
                    $"{car.Home};" +
                    $"{car.ReturnDate.Day}/" +
                    $"{car.ReturnDate.Month}/" +
                    $"{car.ReturnDate.Year}");
                //TODO: ReservedToId
            }
        }

        static public void SaveAllCars(List<string[]> cars)
        {
            using (TextWriter writer = new StreamWriter(_carPath))
            {
                foreach (string[] arr in cars)
                {
                    //0-7
                    for (int i = 0; i < arr.Length; i++)
                    {
                        writer.Write($"{arr[i]};");
                    }
                }
            }
        }
        static public void UpdateCar(string[] car)
        {
            using (StreamReader reader = new StreamReader(_carPath))
            {
                //TODO: Finish UpdateCar (Return)
                List<string[]> cars = ReadAllCars();
                cars.Remove(cars.Find(c => c[0] == car[0]));
                cars.Add(car);
                SaveAllCars(cars);
            }
        }

        static public List<string[]> ReadAllCars()
        {
            using (StreamReader reader = new StreamReader(_carPath))
            {
                //TODO: ReservedToId
                List<string[]> cars = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lines = line.Split(';');

                    cars.Add(lines);
                }
                return cars;
            }
        }

        //possibly useless
        static public void LoadCar(int id)
        {
            throw new System.NotImplementedException();
        }




        static public void SaveCustomers(Customer customer)
        {
            using (TextWriter writer = new StreamWriter(_customerPath, true))
            {
                writer.Write($"{customer.Name};");
                writer.Write($"{customer.Id};");
                writer.Write($"{customer.Age};");
                writer.Write($"{customer.RentedCarId}");
            }
        }

        static public List<string[]> RealAllCustomers()
        {
            using (StreamReader reader = new StreamReader(_customerPath))
            {
                List<string[]> customers = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] lines = line.Split(';');

                    customers.Add(lines);
                }
                return customers;
            }
        }


    }
}
