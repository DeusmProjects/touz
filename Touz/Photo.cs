using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touz
{
    class Photo
    {
        public string Url { get;  set; }

        public string Discription { get;  set; }

        public Photo(string url, string discription)
        {
            Url = url;
            Discription = discription;
        }
    }
}
