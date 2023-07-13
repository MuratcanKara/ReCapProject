using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, SouthwindContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails(Brand brand)
        {
            using (SouthwindContext context = new SouthwindContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars on b.BrandId equals c.BrandId
                             join co in context.Colors on b.BrandId equals co.BrandId
                             select new BrandDetailDto { BrandName = b.Name, CarName = c.Name, ColorName = co.Name };

                return result.ToList();
            }
        }
    }
}
