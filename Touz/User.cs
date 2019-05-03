using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touz
{
    class User
    {
        public User()
        {
            Photos = new List<string>();
        }

        public string Name { get; set; }

        public string Ref { get; set; } 

        public string Avatar { get; set; }

        public List<string> Photos { get; set; } 
    }
}
