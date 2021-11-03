using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dining_Philosophers
{
    class Fork
    {
        public string ForkName { get; set; }
        public bool ForkOccupied { get; set; }

        public Fork (string forkname, bool forkocupied)
        {
            ForkName = forkname;

            ForkOccupied = forkocupied;

        }
    }
}
