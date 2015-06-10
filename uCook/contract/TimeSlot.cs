using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookContract
{
    [Serializable]
    public class TimeSlot
    {
        public int orderNr { get; private set; }
        public int duration { get; private set; }
        public string action { get; private set; }
        public Appliances appliance { get; private set; }

        public TimeSlot(int orderNr, int duration, string action, Appliances appliance)
        {
            this.orderNr = orderNr;
            this.duration = duration;
            this.action = action;
            this.appliance = appliance;
        }
    }
}
