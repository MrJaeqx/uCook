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
            recipeDatabase.Add(fruitSmoothieDummy());
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
            rijst.timeLine.addTimeSlot("Wacht tot het water kookt", 0, Appliances.uCook_Waterkoker);
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

        private Recipe fruitSmoothieDummy()
        {
            Recipe fruitSmoothie = new Recipe();
            fruitSmoothie.name = "Lekkere fruit smoothie.";
            fruitSmoothie.addIngredient(new Ingredient("bannaan", "1 stuk"));
            fruitSmoothie.addIngredient(new Ingredient("yoghurt", "500 ml"));
            fruitSmoothie.addIngredient(new Ingredient("Aardbei", "1 doosje"));
            fruitSmoothie.addAppliance(Appliances.none);
            fruitSmoothie.addAppliance(Appliances.uCook_Blender);
            fruitSmoothie.timeLine.addTimeSlot("Snij de bannaan in schijfjes.", 0, Appliances.none);
            fruitSmoothie.timeLine.addTimeSlot("Snij de aardbeien in stukjes.", 0, Appliances.none);
            fruitSmoothie.timeLine.addTimeSlot("Doe het fruit in de blender.", 0, Appliances.none);
            fruitSmoothie.timeLine.addTimeSlot("Doe de yoghurt in de blender.", 0, Appliances.none);
            fruitSmoothie.timeLine.addTimeSlot("Wacht tot de blender klaar is.", 0, Appliances.uCook_Blender);
            fruitSmoothie.timeLine.addTimeSlot("Schenk uit.", 0, Appliances.none);
            fruitSmoothie.setTotalTime();
            return fruitSmoothie;
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
