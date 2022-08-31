using RentACar.Service.Interface;
using System.Collections.Generic;

namespace RentACar.Service.Repository;

public class Repository : IRepository
{

    #region Car methods
    public Car CreateCar()
    {
        return new Car();
    }
    #endregion

    #region Customer methods
    public Customer CreateCustomer()
    {
        throw new System.NotImplementedException();
    }
    public void DisableCustomer()
    {
        throw new System.NotImplementedException();
    }
    public List<Customer> GetAllCustomers()
    {
        throw new System.NotImplementedException();
    }
    public Customer GetCustomer()
    {
        throw new System.NotImplementedException();
    }
    public void UpdateCustomer()
    {
        throw new System.NotImplementedException();
    } 
    #endregion


}