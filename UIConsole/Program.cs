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
            CarManager carManager = new CarManager( new EfCarsDal());
            carManager.Add(new Car {Id=55,BrandId=3,ColorId=4,DailyPrice=0,
                Description="ikinci el",ModelYear=2020 });

            foreach (var car in carManager.GetCarsDetails())
            {
                Console.WriteLine(car.BrandName+ " " + car.ColorName+ " "+ car.CarId);
            }

        }                                               
    }
}