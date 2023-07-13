using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.SucceededMessage);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new ErrorResult(Messages.FailedMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.SucceededMessage);
        }

        public IDataResult<Color> GetById(int Id)
        {
            return new ErrorDataResult<Color>(_colorDal.Get(c=>c.ColorId==Id), Messages.FailedMessage);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.SucceededMessage);
        }
    }
}
