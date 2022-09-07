using RentACar.Service;
using RentACar.Service.Repository;

namespace RentACarXUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestFines()
        {
            Car car = new Car(10,"Brand", "Model", "Color", 100,129000, false, new DateTime(06/09/22), 0);

        }
    }
}