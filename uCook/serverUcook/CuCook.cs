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
            recipeDatabase.Add(rijstDummy());
            Console.WriteLine("number of items in database: {0}", recipeDatabase.Count);
        }

        private Recipe pastaDummy()
        {
            Recipe pasta = new Recipe();
            pasta.name = "Pasta voor 1 persoon";
            pasta.addIngredient(new Ingredient("pennen", "150g"));
            pasta.addAppliance("uCook Kookpan");
            pasta.timeLine.addTimeSlot("Doe 1L water in de uCook waterkoker.", 1);
            pasta.timeLine.addTimeSlot("Voeg de pasta toe aan het water", 1);
            pasta.timeLine.addTimeSlot("Wacht tot de pasta klaar is", 25);
            pasta.timeLine.addTimeSlot("giet de pasta af en schep op", 1);
            pasta.setTotalTime();
            return pasta;
        }

        private Recipe rijstDummy()
        {
            Recipe rijst = new Recipe();
            rijst.name = "Rijst voor 1 persoon";
            rijst.addIngredient(new Ingredient("Rijst", "100g"));
            rijst.addAppliance("uCook Kookpan");
            rijst.addAppliance("uCook Waterkoker");
            rijst.timeLine.addTimeSlot("Doe 1L water in de uCook Waterkoker.", 1);
            rijst.timeLine.addTimeSlot("Wacht tot het water kookt", 5);
            rijst.timeLine.addTimeSlot("Giet het kokende water over in de uCook Kookpan", 1);
            rijst.timeLine.addTimeSlot("Doe de rijst in de pan met kokend water", 1);
            rijst.timeLine.addTimeSlot("Wacht tot de rijst klaar is.", 8);
            rijst.timeLine.addTimeSlot("Giet de rijst af", 1);
            rijst.setTotalTime();
            return rijst;
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
                    foreach (String a in r.appliances)
                    {
                        if (a.Contains(searchInfo) && !result.Contains(r))
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
