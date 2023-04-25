using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleTrial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTest1();
            

        }

        private static void CarTest1()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());

            Car car1 = new Car();
            
            car1.Id = 12; // It can be deleted or updated as you specify exact id.
            car1.Name = "BMW";
            car1.DailyPrice = 55;
            car1.Description = "Super BMW";

            //Car car2 = new Car();

            //car2.Name = "Nissan";
            //car2.DailyPrice = 99;
            //car2.Description = "Old-school";

            //carManager1.Add(car1);
            //carManager1.Delete(car1);
            //carManager1.Update(car1);

            foreach (var c in carManager1.GetAll())
            {
                Console.WriteLine(c.Name);
            }

        }


    }
}