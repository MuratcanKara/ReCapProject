using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    //Entity.Concrete altında bu nesneyi tanımlasaydık IEntity'i Core katmanından zaten referans aldığı için User'ın usingini bir daha
    //Core katmanı içinde kullanamazdık. Bu yüzden de User'ı Core içinde tanımlamak gerekir. Yani katmanlardan biri diğerini referans 
    //ettiğinde diğeri de birini referans edemez.
    public class User: IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
