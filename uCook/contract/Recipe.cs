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
        public string name { get; set; }
        public int totalTime { get; private set; }     //totale time in minutes
        public List<Ingredient> ingredients { get; private set; }
        public List<String> appliances { get; private set; }
        public TimeLine timeLine { get; private set; }

        public Recipe()
        {
            name = "";
            totalTime = 0;

            ingredients = new List<Ingredient>();
            appliances = new List<String>();
            timeLine = new TimeLine();
        }

        public void setTotalTime()
        {
            foreach (TimeSlot t in timeLine.timeLine)
            {
                totalTime += t.duration;
            }
        }

        public bool addIngredient(Ingredient ingredient)
        {
            bool unique = true;

            foreach (Ingredient i in ingredients)
            {
                if(ingredient.name == i.name)
                {
                    unique = false;
                }
            }

            if(unique)
            {
                ingredients.Add(ingredient);
            }

            return unique;
        }

        public bool addAppliance(String appliance)
        {
            bool unique = true;

            foreach (String a in appliances)
            {
                if (appliance == a)
                {
                    unique = false;
                }
            }

            if (unique)
            {
                appliances.Add(appliance);
            }

            return unique;
        }
    }
}
