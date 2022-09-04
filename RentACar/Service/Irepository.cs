using System;
using System.Collections.Generic;

namespace RentACar.Service.Interface;

public interface IRepository
{

    #region Car stuff
    public void RentCar(int id);
    void CreateNewCar(string brand, string model, string color, string km, string price, bool home, DateTime returnDate);
    public Car UpdateCar(Car car);
    public Car GetCarById(int id);
    public List<string[]> GetAllCars();
    #endregion


    #region Customer stuff
    public Customer CreateCustomer(string name, int age);
    public Customer GetCustomerById(int id);
    public List<Customer> GetAllCustomers();
    public void UpdateCustomer();
    public void DisableCustomer();
    #endregion
}
