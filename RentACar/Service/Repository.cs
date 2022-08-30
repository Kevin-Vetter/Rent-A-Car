using RentACar.Service.Interface;

namespace RentACar.Service.Repository;

public class Repository : IRepository
{
    public Car CreateCar()
    {
        return new Car();
    }
}