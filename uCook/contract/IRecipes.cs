﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace uCookContract
{
    [ServiceContract(Namespace = "uCookContract")]
    public interface IRecipes
    {
        [OperationContract]
        Recipe sendRecipe(string name);

        [OperationContract]
        List<Recipe> findRecipe(string searchInfo);

        [OperationContract]
        void addRecipe(Recipe recipe);

        [OperationContract]
        void removeRecipe(string naam);
    }
}
