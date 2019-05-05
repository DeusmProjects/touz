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
            Photos = new List<Photo>();
        }

        public string Name { get; set; }

        public string Ref { get; set; } 

        public string Avatar { get; set; }

        public string About { get; set; }

        public List<Photo> Photos { get; set; }

        public override string ToString()
        {
            return  Name + "\n" + 
                    Ref + "\n" +
                    Avatar + "\n" +
                    About + "\n";
        }
    }
}
