using RentACar.Service.Interface;
using System;
using System.Collections.Generic;

namespace RentACar.Service.Repository;
public class Repository : IRepository
{
    #region Car 
    private List<Car> _cars = new(CreateAllCars());

    public void RentCar(int id)
    {
        //TODO: DO Rest of Rent CAR!!!
        Car selectedCar = _cars.Find(x => x.Id == id);
    }
    public void CreateNewCar(string brand, string model, string color, string km, string price, bool home, DateTime returnDate)
    {
        Car car = new Car(
            _cars.Count + 1,
            brand,
            model,
            color,
            Convert.ToInt32(km),
            Convert.ToInt32(price),
            home,
            returnDate); ;
        DAL.Stream.SaveCar(car);
        _cars.Add(car);
    }
    static private List<Car> CreateAllCars()
    {
        List<Car> cars = new List<Car>();
        List<string[]> arrayList = new(DAL.Stream.ReadAllCars());
        foreach (string[] arr in arrayList)
        {
            cars.Add(new Car(Convert.ToInt32(arr[0]),
                arr[1],
                arr[2],
                arr[3],
                Convert.ToInt32(arr[4]),
                Convert.ToInt32(arr[5]),
                Convert.ToBoolean(arr[6]),
                Convert.ToDateTime(arr[7])));
        }
        return cars;
    }
    public Car UpdateCar(Car car)
    {
        throw new System.NotImplementedException();
    }

    public bool CarInStore(int id)
    {
        if (GetCarById(id).Home)
            return true;
        return false;
    }

    public Car GetCarById(int id)
    {
        return _cars.Find(x => x.Id == id);
    }
    public List<string[]> GetAllCars()
    {
        return DAL.Stream.ReadAllCars();
    }
    #endregion

    #region Customer

    private List<Customer> _customers = CreateAllCustomers();


    static private List<Customer> CreateAllCustomers()
    {
        List<Customer> customers = new List<Customer>();
        List<string[]> arrayList = new(DAL.Stream.RealAllCustomers());
        foreach (string[] arr in arrayList)
        {
            if (string.IsNullOrEmpty(arr[3]))
            {
                customers.Add(new Customer(arr[1],
                        Convert.ToInt32(arr[0]),
                        Convert.ToInt32(arr[2])));
            }
            else
                customers.Add(new Customer(arr[0],
                    Convert.ToInt32(arr[1]),
                    Convert.ToInt32(arr[2]),
                    Convert.ToInt32(arr[3])));
        }
        return customers;
    }

    public Customer CreateCustomer(string name, int age)
    {
        Customer customer = new(name, _customers.Count + 1, age);
        DAL.Stream.SaveCustomers(customer);
        _customers.Add(customer);

        return customer;
    }
    public Customer GetCustomerById(int id)
    {
        throw new System.NotImplementedException();
    }
    public List<Customer> GetAllCustomers()
    {
        throw new System.NotImplementedException();
    }
    public void UpdateCustomer()
    {

        throw new System.NotImplementedException();

    }
    public void DisableCustomer()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
