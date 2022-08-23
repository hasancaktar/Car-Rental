using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager( new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                
                Console.WriteLine("Brand ID: "+car.BrandId + ", Desc: "+car.Description);
            }
        }                                               
    }
}