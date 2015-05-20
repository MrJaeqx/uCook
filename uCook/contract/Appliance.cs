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
        public int ID { get; private set; }
        public double price { get; private set; } //prices in euros
        public string name { get; private set; }

        public Appliance(int ID, double price, string name)
        {
            this.ID = ID;
            this.price = price;
            this.name = name;
        }
    }
}
