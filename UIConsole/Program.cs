using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarAddTest();
            GetAllTest();
            GetCarsDetailsTest();

        }

        private static void GetCarsDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsDetails())
            {
                Console.WriteLine(car.BrandName + " : " + car.ColorName + " : " + car.CarId);
            }
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId);

            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                Id = 55,
                BrandId = 3,
                ColorId = 4,
                DailyPrice = 1000,
                Description = "ikinci el",
                ModelYear = 2020
            });

            foreach (var car in carManager.GetCarsDetails())
            {
                Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.CarId);
            }
        }
    }
}