using System.Collections.Generic;

namespace RentACar.Service.Interface;

public interface IRepository
{
    public void RentCar();
    public Car CreateCar();
    public Car UpdateCar(Car car);
    public Car GetCarById(int id);



    public Customer CreateCustomer(string name, int age);
    public Customer GetCustomerById(int id);
    public List<Customer> GetAllCustomers();
    public void UpdateCustomer();
    public void DisableCustomer();
}