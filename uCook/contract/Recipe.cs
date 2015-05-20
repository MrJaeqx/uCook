using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uCookContract
{
    [Serializable]
    public class Recipe
    {
        public int ID { get; private set; }
        public string name { get; private set; }
        public int totalTime { get; private set; }     //totale time in minutes
        public List<Ingredient> ingredients { get; private set; }
        public List<Appliance> appliances { get; private set; }
        public TimeLine timeLine { get; private set; }

        public Recipe(int ID, string name)
        {
            this.ID = ID;
            this.name = name;

            totalTime = 0;

            ingredients = new List<Ingredient>();
            appliances = new List<Appliance>();
            timeLine = new TimeLine();
        }


    }
}
