using System;

namespace RentACar.Service;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public Customer(string name, int id, int age)
    {
        Name = name;
        Id = id;
        Age = age;
    }

    //TODO: START DOING CUSTOMER CSV X( (Copy paste maybe)
}
