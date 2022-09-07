using RentACar.Service.Interface;
using System;
using System.Collections.Generic;

namespace RentACar.Service.Repository;
public class Repository : IRepository
{
    #region Car 
    private List<Car> _cars = new(CreateAllCars());

    /// <summary>
    /// Creates all cars from file cars.csv
    /// </summary>
    /// <returns>list of said cars</returns>
    static private List<Car> CreateAllCars()
    {
        List<Car> cars = new List<Car>();
        List<string[]> arrayList = new(DAL.Stream.ReadAllCars());
        foreach (string[] arr in arrayList)
        {
            if (Convert.ToInt32(arr[5]) > 199999)
                continue;
            cars.Add(new Car(Convert.ToInt32(arr[0]),
                arr[1],
                arr[2],
                arr[3],
                Convert.ToInt32(arr[4]),
                Convert.ToInt32(arr[5]),
                Convert.ToBoolean(arr[6]),
                Convert.ToDateTime(arr[7]),
                Convert.ToInt32(arr[8])));
        }
        return cars;
    }
    public void CreateNewCar(string brand, string model, string color, string km, string price, bool home, DateTime returnDate, int reservedToId)
    {
        Car car = new Car(
            _cars.Count + 1,
            brand,
            model,
            color,
            Convert.ToInt32(km),
            Convert.ToInt32(price),
            home,
            returnDate,
            reservedToId);
        DAL.Stream.SaveCar(car);
        _cars.Add(car);
    }
    public bool CarInStore(int id)
    {
        if (GetCarById(id) != null)
        {
            if (GetCarById(id).Home)
            {
                return true;
            }
        }
        return false;
    }
    public Car GetCarById(int id)
    {
        Car selectedCar = _cars.Find(x => x.Id == id);
        if (selectedCar == null)
            return null;
        return selectedCar;
    }
    public List<string[]> GetAllCars()
    {
        return DAL.Stream.ReadAllCars();
    }
    public void ReserveCar(int carId, int customerId)
    {
        Customer customer = GetCustomerById(customerId);
        Car car = GetCarById(carId);
        car.ReservedToId = customerId;
        DAL.Stream.UpdateCar(car);
    }
    public void RentCar(int carId, int customerId)
    {
        Car car = GetCarById(carId);
        if (/*carId == customerId &&*/ car.ReservedToId == customerId)
        {
            Customer customer = GetCustomerById(customerId);
            customer.RentedCarId = carId;
            car.ReturnDate = DateTime.Today.AddDays(7);
            car.Home = false;
            car.ReservedToId = 0;
            DAL.Stream.UpdateCustomer(customer);
            DAL.Stream.UpdateCar(car);
        }
    }
    public void ReturnCar(int customerId, int addedKm)
    {
        Customer customer = GetCustomerById(customerId);
        Car car;
        if (customer.RentedCarId != null)
        {
            car = GetCarById((int)customer.RentedCarId);
            car.ReturnDate = DateTime.MinValue;
            car.Km += addedKm;
            car.Home = true;
            DAL.Stream.UpdateCar(car);
            DAL.Stream.UpdateBooks(car);
            customer.RentedCarId = 0;
            DAL.Stream.UpdateCustomer(customer);
        }
    }
    #endregion

    #region Customer

    private List<Customer> _customers = CreateAllCustomers();


    static private List<Customer> CreateAllCustomers()
    {
        List<Customer> customers = new List<Customer>();
        List<string[]> arrayList = new(DAL.Stream.ReadAllCustomers());
        foreach (string[] arr in arrayList)
        {
            if (string.IsNullOrEmpty(arr[3]))
            {
                customers.Add(new Customer(arr[0], Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2])));
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
        DAL.Stream.SaveCustomer(customer);
        _customers.Add(customer);

        return customer;
    }
    public Customer GetCustomerById(int id)
    {
        return _customers.Find(c => c.Id == id);
    }
    public bool DoesCustomerExist(int id)
    {
        if (_customers.Find(c => c.Id == id) != null)
            return true;
        return false;
    }
    #endregion

    #region Books
    public int ViewBooks()
    {
        return DAL.Stream.GetBooks();
    }
    public void ExtraPay(int ammount)
    {
        DAL.Stream.ExtraPay(ammount);
    }
    #endregion
}
