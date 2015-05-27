using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using uCookContract;

namespace serverUcook
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class CuCook : IRecipes
    {
        private List<Recipe> recipeDatabase;

        public CuCook()
        {
            recipeDatabase = new List<Recipe>();
            recipeDatabase.Add(pastaDummy());
            Console.WriteLine("number of items in database: {0}", recipeDatabase.Count);
        }

        private Recipe pastaDummy()
        {
            Recipe pasta = new Recipe(recipeDatabase.Count, "pasta voor 1 persoon");
            pasta.ingredients.Add(new Ingredient("pennen", "150g"));
            pasta.appliances.Add(new Appliance(pasta.appliances.Count, 50.0, "uCook Kookpan"));;
            pasta.timeLine.addTimeSlot("Doe 1L water in de uCook kookpan.", 10);
            pasta.timeLine.addTimeSlot("Voeg de pasta toe aan het water", 12);
            pasta.timeLine.addTimeSlot("giet de pasta af en schep op", 1);
            pasta.setTotalTime();
            return pasta;
        }

        public Recipe sendRecipe(string name)
        {
            Console.WriteLine("sendRecipe was called with parameter: {0}", name);

            foreach(Recipe r in recipeDatabase)
            {
                if (r.name == name)
                {
                    return r;
                }
            }

            return null;
        }

        public List<Recipe> findRecipe(string searchInfo)
        {
            Console.WriteLine("findRecipe was called with parameter: {0}", searchInfo);
            List<Recipe> result = new List<Recipe>();

            foreach (Recipe r in recipeDatabase)
            {
                Console.WriteLine("found in recipe title: {0}", r.name.Contains(searchInfo));
                if (r.name.Contains(searchInfo))
                {
                    result.Add(r);
                }
                else
                {
                    foreach (Ingredient i in r.ingredients)
                    {
                        if (i.name.Contains(searchInfo) && !result.Contains(r))
                        {
                            result.Add(r);
                        }
                    }
                    foreach (Appliance a in r.appliances)
                    {
                        if (a.name.Contains(searchInfo) && !result.Contains(r))
                        {
                            result.Add(r);
                        }
                    }
                    foreach (TimeSlot t in r.timeLine.timeLine)
                    {
                        if (t.action.Contains(searchInfo) && !result.Contains(r))
                        {
                            result.Add(r);
                        }
                    }
                }

            }
            
            return result;

        }

        public bool addRecipe(Recipe recipe)
        {
            Console.WriteLine("addRecipe was called with parameter: {0}", recipe);
            recipeDatabase.Add(recipe);
            return true;
        }

        public bool removeRecipe(string naam)
        {
            Console.WriteLine("removeRecipe was called with parameter: {0}", naam);
            foreach (Recipe r in recipeDatabase)
            {
                if(r.name == naam)
                {
                    recipeDatabase.Remove(r);
                }
            }
            return true;
        }
    }
}
