﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarsDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarsContext context = new CarsContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using(CarsContext context= new CarsContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
          using(CarsContext context= new CarsContext())
            {
                return context.Set<Car>().SingleOrDefault<Car>(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using(CarsContext context= new CarsContext())
            {
                
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using(CarsContext context= new CarsContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<CarDTO> GetCarsDetails()
        {
            using(CarsContext context = new CarsContext())
            {
                var result = from ca in context.Cars
                             join cd in context.Colors
                             on ca.ColorId equals cd.Id
                             join cb in context.Brands
                             on ca.BrandId equals cb.Id
                             select new CarDTO { CarId = ca.Id, BrandName = cb.BrandName, ColorName = cd.ColorName };

                return result.ToList();
            }
            
        }
    }
}