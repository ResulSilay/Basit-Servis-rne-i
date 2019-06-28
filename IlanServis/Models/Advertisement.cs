
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IlanServis.Models
{
    public class Advertisement
    {
        public int id { set; get; }
        public string subject { set; get; }
        public string description { set; get; }
        public int type { set; get; }
        public int status { set; get; }
        public string datetime { set; get; }
    }
}