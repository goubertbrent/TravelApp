using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.DTO
{
    public class RegisterDTO : LoginDTO
    {
        public string Name { get; set; }
    }
}
