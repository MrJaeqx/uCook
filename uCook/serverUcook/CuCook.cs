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
        private List<Appliances> availableAppliances;

        public CuCook()
        {
            recipeDatabase = new List<Recipe>();
            recipeDatabase.Add(pastaDummy());
            recipeDatabase.Add(rijstDummy());
            recipeDatabase.Add(gebakkenAardappelenDummy());
            Console.WriteLine("number of items in database: {0}", recipeDatabase.Count);

            availableAppliances = new List<Appliances>();
            availableAppliances = Enum.GetValues(typeof(Appliances)).Cast<Appliances>().ToList();
        }

        private Recipe pastaDummy()
        {
            Recipe pasta = new Recipe();
            pasta.name = "Pasta voor 1 persoon";
            pasta.addIngredient(new Ingredient("pennen", "150g"));
            pasta.addAppliance(Appliances.uCook_Kookpan);
            pasta.addAppliance(Appliances.uCook_Waterkoker);
            pasta.addAppliance(Appliances.none);
            pasta.timeLine.addTimeSlot("Doe 1L water in de uCook waterkoker.", 0, Appliances.none);
            pasta.timeLine.addTimeSlot("Wacht tot het water kookt", 0, Appliances.uCook_Waterkoker);
            pasta.timeLine.addTimeSlot("Doe het kokende water in de uCook kookpan", 0, Appliances.uCook_Kookpan);
            pasta.timeLine.addTimeSlot("Voeg de pasta toe aan het water", 0, Appliances.uCook_Kookpan);
            pasta.timeLine.addTimeSlot("Wacht tot de pasta klaar is", 25, Appliances.uCook_Kookpan);
            pasta.timeLine.addTimeSlot("giet de pasta af en schep op", 0, Appliances.uCook_Kookpan);
            pasta.setTotalTime();
            return pasta;
        }

        private Recipe rijstDummy()
        {
            Recipe rijst = new Recipe();
            rijst.name = "Rijst voor 1 persoon";
            rijst.addIngredient(new Ingredient("Rijst", "100g"));
            rijst.addAppliance(Appliances.uCook_Kookpan);
            rijst.addAppliance(Appliances.uCook_Waterkoker);
            rijst.addAppliance(Appliances.none);
            rijst.timeLine.addTimeSlot("Doe 1L water in de uCook Waterkoker.", 0, Appliances.none);
            rijst.timeLine.addTimeSlot("Wacht tot het water kookt", 5, Appliances.uCook_Waterkoker);
            rijst.timeLine.addTimeSlot("Giet het kokende water over in de uCook Kookpan", 0, Appliances.uCook_Kookpan);
            rijst.timeLine.addTimeSlot("Doe de rijst in de pan met kokend water", 0, Appliances.uCook_Kookpan);
            rijst.timeLine.addTimeSlot("Wacht tot de rijst klaar is.", 8, Appliances.uCook_Kookpan);
            rijst.timeLine.addTimeSlot("Giet de rijst af", 0, Appliances.none);
            rijst.setTotalTime();
            return rijst;
        }

        private Recipe gebakkenAardappelenDummy()
        {
            Recipe gebakkenAardappelen = new Recipe();
            gebakkenAardappelen.name = "gebakkenAardappelen voor 4!";
            gebakkenAardappelen.addIngredient(new Ingredient("Aardappelschijfjes", "600g"));
            gebakkenAardappelen.addIngredient(new Ingredient("Bakboter", "100g"));
            gebakkenAardappelen.addAppliance(Appliances.none);
            gebakkenAardappelen.addAppliance(Appliances.uCook_Braadpan);
            gebakkenAardappelen.timeLine.addTimeSlot("Doe de boter in de pan.", 0, Appliances.none);
            gebakkenAardappelen.timeLine.addTimeSlot("Wacht tot de boter is gesmolten", 1, Appliances.uCook_Braadpan);
            gebakkenAardappelen.timeLine.addTimeSlot("Doe de aardappelschijfjes in de pan.", 0, Appliances.uCook_Braadpan);
            gebakkenAardappelen.timeLine.addTimeSlot("Roer tijdens het braden af en toe de aardappelschijfjes om", 8, Appliances.uCook_Braadpan);
            gebakkenAardappelen.timeLine.addTimeSlot("Schep de aardappelen op", 0, Appliances.none);
            gebakkenAardappelen.setTotalTime();
            return gebakkenAardappelen;
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

        public List<Appliances> getAvailableAppliances()
        {
            return availableAppliances;
        }
    }
}
