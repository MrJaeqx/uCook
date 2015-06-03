using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookContract
{
    [Serializable]
    public class Appliance
    {
        public string name { get; private set; }

        public Appliance(double price, string name)
        {
            this.name = name;
        }
    }
}
