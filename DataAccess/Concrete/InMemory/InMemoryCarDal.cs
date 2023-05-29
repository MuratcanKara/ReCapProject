//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Net.Http.Headers;
//using System.Runtime.ConstrainedExecution;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccess.Concrete.InMemory
////{
//    //public class InMemoryCarDal : ICarDal
//    //{

//    //    List<Car> _cars;
//    //    public InMemoryCarDal()
//    //    {
//    //        _cars = new List<Car>
//    //        {
//    //            new Car{Id=1, BrandId=1, ColorId=5, DailyPrice=500, Description="BMW", ModelYear= new DateTime(2023, 4, 2)},
//    //            new Car{Id=2, BrandId=2, ColorId=1, DailyPrice=200, Description="NISSAN", ModelYear= new DateTime(2022, 4, 2)},
//    //            new Car{Id=3, BrandId=2, ColorId=2, DailyPrice=200, Description="MERCEDES", ModelYear= new DateTime(2021, 4, 2)},
//    //            new Car{Id=4, BrandId=3, ColorId=3, DailyPrice=600, Description="AUDI", ModelYear= new DateTime(2020, 4, 2)},
//    //            new Car{Id=5, BrandId=4, ColorId=6, DailyPrice=450, Description="HONDA", ModelYear= new DateTime(2019, 4, 2)}
//    //        };
//    //    }


//    //    public void Add(Car car)
//    //    {
//    //        _cars.Add(car);
//    //    }

//    //    public void Delete(Car car)
//    //    {
//    //        Car carToDelete;
//    //        carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
//    //        _cars.Remove(carToDelete);
//    //    }

//    //    public void DeleteById(int Id)
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //    public Car Get(Expression<Func<Car, bool>> filter)
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //    public List<Car> GetAll()
//    //    {
//    //        return _cars;
//    //    }

//    //    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
//    //    {
//    //        return _cars;
//    //    }

//    //    public List<Car> GetById(int Id)
//    //    {
//    //        return _cars.Where(c=>c.Id == Id).ToList();
//    //    }

//    //    public void Update(Car car)
//    //    {
//    //        Car carToUpdate;
//    //        carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
//    //        carToUpdate.DailyPrice = car.DailyPrice;
//    //        carToUpdate.Description = car.Description;
//    //        carToUpdate.ModelYear = car.ModelYear;
//    //        carToUpdate.BrandId = car.BrandId;
//    //        carToUpdate.ColorId = car.ColorId;

//    //    }
//    //}
////}
