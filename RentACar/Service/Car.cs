namespace RentACar.Service;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Km { get; set; }
    public int Price { get; set; }
    public bool Home { get; set; }


    public Car(int id, string brand, string model, string color, int price, int km, bool home)
    {
        Id = id;
        Brand = brand;
        Color = color;
        Model = model;
        Price = price;
        Km = km;
        Home = home;


    }
}