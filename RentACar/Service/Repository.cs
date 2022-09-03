using RentACar.Service.Interface;
using RentACar.DAL;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace RentACar.Service.Repository;
public class Repository : IRepository
{
    #region Car 
    private List<Car> _cars = new(CreateAllCars());

    public void RentCar(int id)
    {
        //TODO: Check home...
        Car selectedCar = _cars.Find(x => x.Id == id);


    }
    public void CreateNewCar(string brand, string model, string color, string km, string price, bool home)
    {
        //Id, Brand, Model, Color, Home

        Car car = new Car(
            _cars.Count + 1,
            brand,
            model,
            color,
            Convert.ToInt32(km),
            Convert.ToInt32(price),
            home);

        DAL.Stream.SaveCar(car);
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
                Convert.ToBoolean(arr[6])));
        }
        return cars;
    }
    public Car UpdateCar(Car car)

    {
        throw new System.NotImplementedException();
    }
    public Car GetCarById(int id)
    {
        throw new System.NotImplementedException();
    }
    public List<string[]> GetAllCars()
    {
        return DAL.Stream.ReadAllCars();
    }
    #endregion

    #region Customer

    private List<Customer> _customers = new();

    public Customer CreateCustomer(string name, int age)
    {
        Customer customer = new(name, _customers.Count + 1, age);

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
