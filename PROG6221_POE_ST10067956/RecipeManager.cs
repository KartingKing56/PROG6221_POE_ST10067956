using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10067956
{
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// AddRecipe method to retrieve a recipe and save it to the list
        /// </summary>
        /// <param name="recipe"></param>

        //------------------------------------------------------------------------

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// DeleteRecipe to delete a recipe within the list
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool DeleteRecipe(string recipeName)
        {
            var recipe = GetRecipe(recipeName);
            if (recipe != null)
            {
                recipes.Remove(recipe);
                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// EditRecipe to allow the user to edit a recipe in the list 
        /// </summary>
        /// <param name="recipeName"></param>
        /// <param name="newRecipe"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool EditRecipe(string recipeName, Recipe newRecipe)
        {
            var recipe = GetRecipe(recipeName);
            if (recipe != null)
            {
                recipe.Name = newRecipe.Name;
                recipe.NumberSteps = newRecipe.NumberSteps;
                recipe.NumberIngreds = newRecipe.NumberIngreds;
                recipe.IngredName = newRecipe.IngredName;
                recipe.IngredQuan = newRecipe.IngredQuan;
                recipe.IngredUOM = newRecipe.IngredUOM;
                recipe.Description = newRecipe.Description;

                return true;
            }
            return false;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// GetRecipe is used in the methods in the class to get a recipe that is currently in the list
        /// </summary>
        /// <param name="recipeName"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public Recipe GetRecipe(string recipeName)
        {
            return recipes.FirstOrDefault(r => r.Name == recipeName);
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// GetAllRecipes used in the interface class to save all the recipes to a local list in that class
        /// </summary>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public List<Recipe> GetAllRecipes()
        {
            return recipes;
        }

        //------------------------------------------------------------------------
    }
}

//---------------------------------------------------end-------------------------------------------------------
