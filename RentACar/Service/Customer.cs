using System;

namespace RentACar.Service;

public class Customer
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Age { get; set; }
    public int? RentedCarId { get; set; }


    public Customer(string name, int id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }
    public Customer(string name, int id, int age, int rentedCarId)
    {
        Name = name;
        Id = id;
        Age = age;
        RentedCarId = rentedCarId;
    }


}
