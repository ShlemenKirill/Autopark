using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class Rent
    {
        public DateTime RentTime { get; set; }
        public double RentCost { get; set; }

        public Rent() { }

        public Rent(DateTime rentTime, double rentCost)
        {
            RentTime = rentTime;
            RentCost = rentCost;
        }
    }
}
