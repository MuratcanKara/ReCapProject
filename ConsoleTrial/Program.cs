using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleTrial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTest1();
            //CustomerTest1();
            //UserTest1();

        }

        private static void UserTest1()
        {
            UserManager userManager1 = new UserManager(new EfUserDal());
            User user1 = new User();

            //user1.UserId = 1;
            user1.FirstName = "Test";
            user1.LastName = "Test";
            user1.Email = "test@gmail.com";
            userManager1.Add(user1);
        }

        private static void CustomerTest1()
        {
            CustomerManager customerManager1 = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer();
            customer1.CompanyName = "TestCompany";
            customer1.UserId = 1;
            customer1.ContactName = "Test";
            customer1.Address = "Test";
            customer1.City = "Test";
            customerManager1.Add(customer1);
        }

        private static void CarTest1()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());                                                           
            Car car1 = new Car();
            
                                            
            
            //car1.CarId = 1; // It can be deleted or updated as you specify exact id.
            car1.Name = "CAR";
            car1.DailyPrice = 22;
            car1.Description = "CAR";
            carManager1.Add(car1);

            
            //Car car2 = new Car();

            //car2.Name = "Nissan";
            //car2.DailyPrice = 99;
            //car2.Description = "Old-school";


            //carManager1.DeleteById(1);
            //carManager1.Update(car1);


            foreach (var c in carManager1.GetAll().Data)
            {
                Console.WriteLine(c.Name);
            }

        }


    }
}