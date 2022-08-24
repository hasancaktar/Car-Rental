using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager( new EfCarsDal());
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                
                Console.WriteLine(car.BrandId);
            }      
        }                                               
    }
}