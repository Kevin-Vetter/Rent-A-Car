using RentACar.Service.Interface;

namespace RentACar;

public class RentACar
{
    public readonly IRepository irepository;


    public RentACar(IRepository irepository)
    {
        this.irepository = irepository;
    }
}
