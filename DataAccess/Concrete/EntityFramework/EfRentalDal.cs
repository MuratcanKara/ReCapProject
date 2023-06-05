using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, SouthwindContext>, IRentalDal
    {
        public bool IsRentable(Rental rental)
        {
            using (SouthwindContext context = new SouthwindContext())
            {
                var isRentable = false;
                var isReturnDateNull = rental.ReturnDate;
                if (isReturnDateNull == null)
                {
                    return isRentable;
                    throw new Exception("The car is not available for renting right now. Try again later!");
                    
                }
                else
                {
                    return isRentable = true;                    
                }
            }
        }
    }
}
