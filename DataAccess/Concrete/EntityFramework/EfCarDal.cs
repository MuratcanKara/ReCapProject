using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SouthwindContext>, ICarDal
    {
        public void DeleteById(int Id)
        {
            using (SouthwindContext context = new SouthwindContext())
            {
                var carToDelete = context.Set<Car>().Find(Id);
                if (carToDelete != null)
                {
                    context.Set<Car>().Remove(carToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Car doesn't exist!");
                }

            }

        }

        public List<CarDetailDto> GetCarDetails(Car car)
        {
            using (SouthwindContext context = new SouthwindContext())
            {
                var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.Id join co in context.Colors on c.ColorId equals co.Id
                             select new CarDetailDto {CarName = c.Name, BrandName = b.Name, ColorName = co.Name, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }

        
    }
}
