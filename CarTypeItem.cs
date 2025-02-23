using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class CarTypeItem
    {
        public CarType Type { get; set; }
        public string Description { get; set; }

        public override string ToString() => Description; 
    }
}
