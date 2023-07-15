using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator)]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);

            return new SuccessResult(Messages.SucceededMessage);
        }

        public IResult Delete(Car car)
        {            
            _carDal.Delete(car);
            return new SuccessResult(Messages.SucceededMessage);
        }

        public IResult DeleteById(int Id)
        {
            //If İLE BURAYI GELİŞTİR. GELİŞTİRMEDEN İLERLEME.           
            _carDal.DeleteById(Id);
            return new ErrorResult(Messages.FailedMessage);
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SucceededMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Car car)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(car), Messages.SucceededMessage);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new ErrorDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SucceededMessage);
        }


    }
}
