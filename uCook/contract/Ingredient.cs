using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookContract
{
    [Serializable]
    public class Ingredient
    {
        public string name { get; private set; } //eg flour, water, etc
        public string amount { get; private set; } //eg 100ml, 200g, etc

        public Ingredient(string name, string amount)
        {
            this.name = name;
            this.amount = amount;
        }
    }
}
