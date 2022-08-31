using System.Collections.Generic;

namespace RentACar.Service.Interface;

public interface IRepository
{
    public Car CreateCar();
    internal Customer CreateCustomer();
    public Customer GetCustomer();
    public List<Customer> GetAllCustomers();
    public void UpdateCustomer();
    public void DisableCustomer();
}