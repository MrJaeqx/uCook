using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uCookContract;

namespace serverUcook
{
    class CuCook : IRecipes
    {
        public Recipe sendRecipe(string name)
        {
            Console.WriteLine("sendRecipe was called with parameter: {0}", name);
            return null;
        }

        public List<Recipe> findRecipe(string searchInfo)
        {
            Console.WriteLine("findRecipe was called with parameter: {0}", searchInfo);
            return null;
        }

        public bool addRecipe(Recipe recipe)
        {
            Console.WriteLine("addRecipe was called with parameter: {0}", recipe);
            return false;
        }

        public bool removeRecipe(string naam)
        {
            Console.WriteLine("removeRecipe was called with parameter: {0}", naam);
            return false;
        }
    }
}
