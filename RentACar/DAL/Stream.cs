using RentACar.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentACar.DAL
{
    public class Stream
    {
        static public void SaveCar(Car car)
        {
            using (TextWriter writer = new StreamWriter(@"C:\Users\kevin\Desktop\Cars.csv", true))
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
            }
        }

        static public List<string[]> ReadAllCars()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\kevin\Desktop\Cars.csv"))
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

        //possibly useless
        static public void LoadCar(int id)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\kevin\Desktop\Cars.csv"))
            {

                while (!reader.EndOfStream)
                {
                    List<string> listA = new List<string>();
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    if (values[0] == id.ToString())
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            listA.Add(values[i]);
                        }
                    }
                }
            }
        }




        static public void SaveCustomers(Customer customer)
        {
            using (TextWriter writer = new StreamWriter(@"C:\Users\kevin\Desktop\Cars.csv", true))
            {
                //writer.WriteLine($"{Customer.Id}");
            }
        }
        
        static public void RealAllUsers(int id)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\kevin\Desktop\Customers.csv"))
            {

                while (!reader.EndOfStream)
                {
                    List<string> listA = new List<string>();
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');
                    if (values[0] == id.ToString())
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                            listA.Add(values[i]);
                        }
                    }
                }
            }
        }


    }
}
