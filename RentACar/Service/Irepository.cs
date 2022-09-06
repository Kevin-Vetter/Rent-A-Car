using System;
using System.Collections.Generic;

namespace RentACar.Service.Interface;

public interface IRepository
{

    #region Car stuff
    /// <summary>
    /// Rents a car to a customer
    /// </summary>
    /// <param name="carId"></param>
    /// <param name="customerId"></param>
    public void RentCar(int carId, int customerId);

    /// <summary>
    /// Returns a car from a customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="addedKm"></param>
    public void ReturnCar(int customerId, int addedKm);

    /// <summary>
    /// Creates new car object and saves it in file
    /// </summary>
    /// <param name="brand"></param>
    /// <param name="model"></param>
    /// <param name="color"></param>
    /// <param name="km"></param>
    /// <param name="price"></param>
    /// <param name="home"></param>
    /// <param name="returnDate"></param>
    /// <param name="reservedToId"></param>
    void CreateNewCar(string brand, string model, string color, string km, string price, bool home, DateTime returnDate, int reservedToId);

    /// <summary>
    /// Gets a car by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Car object</returns>
    public Car GetCarById(int id);

    /// <summary>
    /// Gets all cars as a list of string arrays
    /// </summary>
    /// <returns>all cars in a list of string arrays</returns>
    public List<string[]> GetAllCars();

    /// <summary>
    /// Checks if a specific car is in store
    /// </summary>
    /// <param name="id"></param>
    /// <returns>true or false</returns>
    public bool CarInStore(int id);
    #endregion


    #region Customer stuff
    /// <summary>
    /// Creates a new customer and saves it
    /// </summary>
    /// <param name="name"></param>
    /// <param name="age"></param>
    /// <returns>said customer object</returns>
    public Customer CreateCustomer(string name, int age);

    /// <summary>
    /// Gets customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>returns said customer object</returns>
    public Customer GetCustomerById(int id);

    /// <summary>
    /// Checks if specfic customer exists
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True or False</returns>
    public bool DoesCustomerExist(int id);

    /// <summary>
    /// Reserves a car to a customer
    /// </summary>
    /// <param name="carId"></param>
    /// <param name="customerId"></param>
    public void ReserveCar(int carId, int customerId);
    #endregion



    /// <summary>
    /// gets sum of all lines in books.csv
    /// </summary>
    /// <returns>int sum</returns>
    public int ViewBooks();

    /// <summary>
    /// Adds extra fee from the carwash
    /// </summary>
    /// <param name="ammount"></param>
    public void ExtraPay(int ammount);
}
