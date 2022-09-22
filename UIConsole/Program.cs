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
            // CarAddTest();
            // GetAllTest();
            GetCarsDetailsTest();
            // CarDeleteTest();
            //CarUpdateTest();
            //UserAddTest();
           // CustomerAddTest();
           RentalAdd();
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental
            {
                CarId = 1,
                ReturnDate = new DateTime(2022),
                CustomerId = 1,
                Id = 1,
                RentDate = new DateTime(2021)
            });
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                Id = 1,
                CompanyName = "Şirket1",
                UserId = 1
            });
        }

        private static void UserAddTest()
        {
            UserManager usersManager = new UserManager(new EfUserDal());
            usersManager.Add(new User
            {
                Id = 1,
                FirstName = "Hasan",
                LastName = "Sancaktar",
                Email = "lordhasan@gmail.com",
                //Password = "123456"
            });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 5, BrandId = 2, ColorId = 2, ModelYear = 2012, DailyPrice = 650, Description = "ikinci el" });
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 5 });
            
            
            foreach (var car in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.CarId);
            }

        }

        private static void GetCarsDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsDetails();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarsDetails().Data)
                {
                    Console.WriteLine(car.BrandName + " : " + car.ColorName + " : " + car.CarId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
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

            foreach (var car in carManager.GetCarsDetails().Data)
            {
                Console.WriteLine(car.BrandName + " " + car.ColorName + " " + car.CarId);
            }
        }
    }
}