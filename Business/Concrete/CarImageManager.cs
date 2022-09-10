using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public  CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)

        {
            _carImageDal=carImageDal;
            _fileHelper=fileHelper;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.CarPath = _fileHelper.Upload(file, PathConstants.imagesPath);
            carImage.Date= DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.SuccessImageUpload);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.imagesPath+carImage.CarPath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.SuccessImageDelete);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
           
            _fileHelper.Update(file, PathConstants.imagesPath + carImage.CarPath, PathConstants.imagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.SuccessImageUpdate);
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, CarPath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
