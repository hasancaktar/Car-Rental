using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        BrandManager(IBrandDal brand)
        {
            _brandDal=brand;
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
    }
}
