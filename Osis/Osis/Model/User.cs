using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osis.Model
{
    public class User
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
    }
}
