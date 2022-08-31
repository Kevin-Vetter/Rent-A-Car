using RentACar.Service.Interface;
using System.Collections.Generic;


namespace RentACar.Service.Repository;
public class Repository : IRepository
{
    #region Car methods
    public void RentCar()
    {

    }

    public Car CreateCar()
    {
        return new Car();
    }

    public Car UpdateCar(Car car)

    {
        throw new System.NotImplementedException();
    }

    public Car GetCarById(int id)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Customer

    readonly List<Customer> customers = new();

    public Customer CreateCustomer(string name, int age)
    {
        Customer customer = new(name, customers.Count + 1, age);

        customers.Add(customer);

        return customer;
    }

    public void DisableCustomer()
    {
        throw new System.NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new System.NotImplementedException();
    }

    public Customer GetCustomerById(int id)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateCustomer()
    {

        throw new System.NotImplementedException();

    }
    #endregion
}
