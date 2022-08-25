using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;


        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=50000,Description="Sıfır",ModelYear=2022},
                new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=80000,Description="İkinci El",ModelYear=2010},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=90000,Description="İkinci El",ModelYear=2015},
                new Car{Id=4,BrandId=3,ColorId=4,DailyPrice=100000,Description="Sıfır",ModelYear=2022},
                new Car{Id=5,BrandId=4,ColorId=5,DailyPrice=70000,Description="İkinci El",ModelYear=2009},
                new Car{Id=6,BrandId=5,ColorId=6,DailyPrice=65000,Description="İkinci El",ModelYear=2000},
                new Car{Id=7,BrandId=5,ColorId=6,DailyPrice=15000,Description="Sıfır",ModelYear=2022}
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Eklendi");
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(x => x.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Id = car.Id;

        }
    }
}
