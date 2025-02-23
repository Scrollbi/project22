using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class RequestStatusItem
    {
        public RequestStatus Status { get; set; }
        public string Description { get; set; }

        public override string ToString() => Description; 
    }

}
