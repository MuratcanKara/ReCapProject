using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Services.FileServices.GuidService
{
    public class GuidService
    {
        public static string CreateGuid()
        {
            string newGuid = Guid.NewGuid().ToString();
            return newGuid;
        }
    }
}
