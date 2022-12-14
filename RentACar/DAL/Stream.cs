using Microsoft.VisualBasic;
using RentACar.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace RentACar.DAL
{
    public class Stream
    {
        private static readonly string _carPath = @"C:\Users\kevin\source\repos\RentACar\RentACar\Database\Cars.csv";
        private static readonly string _customerPath = @"C:\Users\Kevin\source\repos\RentACar\RentACar\Database\Customers.csv";
        private static readonly string _booksPath = @"C:\Users\Kevin\source\repos\RentACar\RentACar\Database\Books.csv";

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
                    $"{car.ReturnDate.Year};" +
                    $"{car.ReservedToId}");
            }
        }
        static public void SaveAllCars(List<string[]> cars)
        {
            using (TextWriter writer = new StreamWriter(_carPath))
            {
                foreach (string[] arr in cars)
                {
                    writer.WriteLine($"" +
                    $"{arr[0]};" +
                    $"{arr[1]};" +
                    $"{arr[2]};" +
                    $"{arr[3]};" +
                    $"{arr[4]};" +
                    $"{arr[5]};" +
                    $"{arr[6]};" +
                    $"{arr[7]};" +
                    $"{arr[8]}");
                }
            }
        }
        static public void UpdateCar(Car car)
        {
            List<string[]> cars = ReadAllCars();
            cars.Remove(cars.Find(c => c[0] == car.Id.ToString()));
            List<string> list = new();
            if (car.ReservedToId != null)
            {
                list.Add(car.Id.ToString());
                list.Add(car.Brand);
                list.Add(car.Model);
                list.Add(car.Color);
                list.Add(car.Price.ToString());
                list.Add(car.Km.ToString());
                list.Add(car.Home.ToString());
                list.Add(car.ReturnDate.ToShortDateString());
                list.Add(car.ReservedToId.ToString());
            }
            cars.Add(list.ToArray());
            SaveAllCars(cars);
        }
        static public List<string[]> ReadAllCars()
        {
            using (StreamReader reader = new StreamReader(_carPath))
            {
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
        static public void UpdateCustomer(Customer customer)
        {
            List<string[]> customers = ReadAllCustomers();
            customers.Remove(customers.Find(c => c[1] == customer.Id.ToString()));
            List<string> list = new();
            if (customer.RentedCarId != null)
            {
                list.Add(customer.Name);
                list.Add(customer.Id.ToString());
                list.Add(customer.Age.ToString());
                list.Add(customer.RentedCarId.ToString());
            }
            //THIS IS FOR IF UPDATE CUSTOMER BREAKS X(
            //else
            //{
            //    list.Add(customer.Name);
            //    list.Add(customer.Id.ToString());
            //    list.Add(customer.Age.ToString());
            //}

            customers.Add(list.ToArray());
            SaveAllCustomers(customers);
        }
        static public void SaveAllCustomers(List<string[]> customers)
        {
            using (TextWriter writer = new StreamWriter(_customerPath))
            {
                foreach (string[] customer in customers)
                    if (customer[3] != null || customer[3] != "0")
                    {
                        writer.WriteLine($"{customer[0]};" +
                            $"{customer[1]};" +
                            $"{customer[2]};" +
                            $"{customer[3]}");
                    }
                    else
                    {
                        writer.WriteLine($"{customer[0]};" +
                            $"{customer[1]};" +
                            $"{customer[2]}");
                    }
            }
        }
        static public void SaveCustomer(Customer customer)
        {
            using (TextWriter writer = new StreamWriter(_customerPath, true))
            {
                if (customer.RentedCarId != null)
                {
                    writer.WriteLine($"{customer.Name};" +
                        $"{customer.Id};" +
                        $"{customer.Age};" +
                        $"{customer.RentedCarId}");
                }
                else
                {
                    writer.WriteLine($"{customer.Name};" +
                        $"{customer.Id};" +
                        $"{customer.Age};");
                }

            }
        }
        static public List<string[]> ReadAllCustomers()
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

        #region Books

        static public void UpdateBooks(Car car)
        {
            using (TextWriter writer = new StreamWriter(_booksPath, true))
            {
                writer.WriteLine($"{car.Price}");
            }
        }

        static public int GetBooks()
        {
            int book = 0;
            using (StreamReader reader = new StreamReader(_booksPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int.TryParse(line, out int res);
                    book += res;
                }
            }
            return book;
        }
        static public void ExtraPay(int ammount)
        {
            using (StreamWriter writer= new StreamWriter(_booksPath))
            {
                writer.WriteLine(ammount);
            }
        }
        #endregion
    }
}
