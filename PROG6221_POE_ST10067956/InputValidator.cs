using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10067956
{
    public class InputValidator
    {
        private Dictionary<string, string> validUnits;
        private RecipeManager recipeManager;

        string[] validFoodGroups = new string[6];

        /// <summary>
        /// public method to initialise all the necesary classes and variables
        /// </summary>
        /// <param name="manager"></param>

        //------------------------------------------------------------------------

        public InputValidator(RecipeManager manager)
        {
            validUnits = new Dictionary<string, string>
            {
                { "gram", "g" }, { "grams", "g" },
                { "kilogram", "kg" }, { "kilograms", "kg" },
                { "milliliter", "ml" }, { "milliliters", "ml" },
                { "liter", "l" }, { "liters", "l" },
                { "teaspoon", "tsp" }, { "teaspoons", "tsp" },
                { "tablespoon", "tbsp" }, { "tablespoons", "tbsp" },
                { "cup", "cup" }, { "cups", "cup" },
                { "ounce", "oz" }, { "ounces", "oz" },
                { "pound", "lb" }, { "pounds", "lb" },
                { "piece", "pc" }, { "pieces", "pc" },
                { "slice", "slice" }, { "slices", "slice" },
                { "whole", "whole" }, { "wholes", "whole" },
                { "half", "half" }, { "halves", "half" },
                { "quarter", "quarter" }, { "quarters", "quarter" },
                { "egg", "egg" }, { "eggs", "egg" },
                { "apple", "apple" }, { "apples", "apple" },
                { "banana", "banana" }, { "bananas", "banana" },
                { "carrot", "carrot" }, { "carrots", "carrot" },
                { "potato", "potato" }, { "potatoes", "potato" },
                { "pinch", "pinch"}, { "pinches", "pinch"}
            };

            recipeManager = manager;

            validFoodGroups = new string[]
            {
                "Starchy foods",
                "Vegatables and fruit",
                "Dry beans, peas, lentils and soya",
                "Chicken, fish, meat and eggs",
                "Milk and dairy products",
                "Fats and oil",
                "Water"
            };
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if the name is not null or empty and if it's unique
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidRecipeName(string name)
        {
            return !string.IsNullOrEmpty(name) && IsUniqueRecipeName(name);
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if the number of steps is positive and less than a certain maximum
        /// </summary>
        /// <param name="steps"></param>
        /// <returns></returns>
        
        //------------------------------------------------------------------------

        public bool IsValidNumberOfSteps(int steps)
        { 
            return steps > 0 && steps <= 100;
        }

        /// <summary>
        /// Check if the number of ingredients is positive and less than a certain maximum
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidNumberOfIngredients(int ingredients)
        { 
            return ingredients > 0 && ingredients <= 50;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if the ingredient name is not null or empty
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidIngredientName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if the ingredient quantity is positive and within a certain range
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidIngredientQuantity(double quantity)
        {
            return quantity > 0 && quantity <= 10000;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check the value of the calories per ingredient isn't less than zero
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidCaloryCount(int quantity)
        {
            return quantity > 0 && quantity < 500;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Method to check if the total exceeds 300 Calories
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool CheckTotalCalories(int quantity)
        {
            return quantity > 300;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Validation for the units of measurements
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidIngredientUnit(ref string unit)
        {
            if (string.IsNullOrEmpty(unit))
            {
                return false;
            }

            unit = unit.ToLower();

            if (validUnits.ContainsKey(unit))
            {
                unit = validUnits[unit];
                return true;
            }

            if (validUnits.ContainsValue(unit))
            {
                return true;
            }

            return false;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// simple retrieval of the list in the interface class
        /// </summary>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public string[] getFoodGroupList()
        {
            return validFoodGroups;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// check that the input is in the list of food groups
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidFoodGroupItem(string unit)
        {
            if (string.IsNullOrEmpty(unit))
            {
                return false;
            }

            unit = unit.ToLower();

            if (validFoodGroups.Contains(unit))
            {
                return true;
            }

            return false;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if the step description is not null or empty and if it's not too long
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        public bool IsValidStepDescription(string description)
        {
            return !string.IsNullOrEmpty(description) && description.Length <= 1000;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Check if a recipe with the same name already exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        //------------------------------------------------------------------------

        private bool IsUniqueRecipeName(string name)
        {
            return recipeManager.GetRecipe(name) == null;
        }

        //------------------------------------------------------------------------
    }
}

//---------------------------------------------------end-------------------------------------------------------
