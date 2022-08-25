using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using Core.DataAccess.EntityFamework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDTo> GetCarsDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from ca in context.Cars
                             join cd in context.Colors
                             on ca.ColorId equals cd.Id
                             join cb in context.Brands
                             on ca.BrandId equals cb.Id
                             select new CarDetailDTo { CarId = ca.Id, BrandName = cb.BrandName, ColorName = cd.ColorName };

                return result.ToList();
            }

        }
    }
}