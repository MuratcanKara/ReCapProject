using Business.Abstract;
using Business.Constans;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileService _fileService;
        public CarImageManager(ICarImageDal carImageDal, IFileService fileService)
        {
            _carImageDal = carImageDal;
            _fileService = fileService;

        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitRanOutOf(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileService.SaveImage(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _fileService.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(GetDefaultImageOrShowAssignedImages(carId));
            if (result != null)
            {
                throw new Exception("An error occurred! Make contact with an IT person immediately!");
            }
            else
            {
                var carImages = GetDefaultImageOrShowAssignedImages(carId);
                return new SuccessDataResult<List<CarImage>>(carImages.Data);
            }
        }


        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = _fileService.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitRanOutOf(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result >= 5)
            {
                return new ErrorResult(Messages.CheckIfImageLimitRanOutOf);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImageOrShowAssignedImages(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
   
            if (result > 0)
            {
                var allImages = _carImageDal.GetAll();
                return new SuccessDataResult<List<CarImage>>(allImages);
            }
            else
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.png" });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
        }

    }   
}
