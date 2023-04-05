using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleTrial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager1 = new CarManager(new InMemoryCarDal());
            foreach (var c in carManager1.GetAll())
            {
                Console.WriteLine(c.Description);
            }                                  
        }
    }
}