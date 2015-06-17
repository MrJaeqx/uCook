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
        public List<Appliances> appliances { get; private set; }
        public TimeLine timeLine { get; private set; }

        public Recipe()
        {
            name = "";
            totalTime = 0;

            ingredients = new List<Ingredient>();
            appliances = new List<Appliances>();
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

        public bool addAppliance(Appliances appliance)
        {
            bool unique = true;

            foreach (Appliances a in appliances)
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

    [Serializable]
    public enum Appliances
    {
        none = 0,
        uCook_Kookpan = 1,
        uCook_Braadpan = 2,
        uCook_Wokpan = 3,
        uCook_Grilpan = 4,
        uCook_Waterkoker = 5
    }
}
