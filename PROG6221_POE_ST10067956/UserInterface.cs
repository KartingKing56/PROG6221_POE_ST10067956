using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10067956
{
    public class UserInterface
    {
        //------------------------------------------------------------------------

        private RecipeManager recipeManager;
        private InputValidator inputValidator;

        public UserInterface()
        {
            recipeManager = new RecipeManager();
            inputValidator = new InputValidator(recipeManager);
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// Main method for the interface to be called to the main method in the program class
        /// </summary>

        //------------------------------------------------------------------------

        public void Run()
        {
            Console.WriteLine("Welcome to the Recipe Manager!");

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. Delete a recipe");
                Console.WriteLine("3. Edit a recipe");
                Console.WriteLine("4. View a recipe");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        DeleteRecipe();
                        break;
                    case "3":
                        EditRecipe();
                        break;
                    case "4":
                        ViewRecipe();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// AddRecipe class to add a recipe to the recipe manager class
        /// </summary>

        //------------------------------------------------------------------------

        private void AddRecipe()
        {
            Console.WriteLine("Enter the recipe name:");
            string name = Console.ReadLine();

            if (!inputValidator.IsValidRecipeName(name))
            {
                Console.WriteLine("Invalid recipe name. Please try again.");
                return;
            }

            Console.WriteLine("Enter the number of steps:");
            int numberSteps = int.Parse(Console.ReadLine());

            if (!inputValidator.IsValidNumberOfSteps(numberSteps))
            {
                Console.WriteLine("Invalid number of steps. Please try again.");
                return;
            }

            Console.WriteLine("Enter the number of ingredients:");
            int numberIngreds = int.Parse(Console.ReadLine());

            if (!inputValidator.IsValidNumberOfIngredients(numberIngreds))
            {
                Console.WriteLine("Invalid number of ingredients. Please try again.");
                return;
            }

            List<string> ingredName = new List<string>();
            List<string> ingredQuan = new List<string>();
            List<string> ingredUOM = new List<string>();
            List<string> description = new List<string>();

            for (int i = 0; i < numberIngreds; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                string Ingredname = Console.ReadLine();
                if (!inputValidator.IsValidIngredientName(Ingredname))
                {
                    Console.WriteLine("Invalid ingredient name. Please try again.");
                    return;
                }
                ingredName.Add(name);

                Console.WriteLine($"Enter the quantity of ingredient {i + 1}:");
                double quantity = double.Parse(Console.ReadLine());
                if (!inputValidator.IsValidIngredientQuantity(quantity))
                {
                    Console.WriteLine("Invalid ingredient quantity. Please try again.");
                    return;
                }
                ingredQuan.Add(quantity.ToString());

                Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
                string unit = GetValidUnit();
                if (unit == null)
                {
                    return;
                }
                ingredUOM.Add(unit);

            }

            for (int i = 0; i < numberSteps; i++)
            {
                Console.WriteLine($"Enter the description for step {i + 1}:");
                string desc = Console.ReadLine();
                if (!inputValidator.IsValidStepDescription(desc))
                {
                    Console.WriteLine("Invalid step description. Please try again.");
                    return;
                }
                description.Add(desc);
            }

            Recipe recipe = new Recipe(name, numberSteps, numberIngreds, ingredName, ingredQuan, ingredUOM, description);
            recipeManager.AddRecipe(recipe);

            Console.WriteLine("Recipe added successfully!");
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// DeleteRecipe method to delete a recipe from the recipe manager class
        /// </summary>

        //------------------------------------------------------------------------

        private void DeleteRecipe()
        {
            Console.WriteLine("Enter the name of the recipe you want to delete:");
            string name = Console.ReadLine();

            if (recipeManager.DeleteRecipe(name))
            {
                Console.WriteLine("Recipe deleted successfully!");
            }
            else
            {
                Console.WriteLine("Recipe not found. Please try again.");
            }
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// EditRecipe method to make changes to an existing recipe in the recipe manager class
        /// </summary>

        //------------------------------------------------------------------------

        private void EditRecipe()
        {
            Console.WriteLine("Enter the name of the recipe you want to edit:");
            string name = Console.ReadLine();

            Recipe recipe = recipeManager.GetRecipe(name);
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found. Please try again.");
                return;
            }

            Console.WriteLine("Enter the new recipe name:");
            string newName = Console.ReadLine();
            if (!inputValidator.IsValidRecipeName(newName))
            {
                Console.WriteLine("Invalid recipe name. Please try again.");
                return;
            }
            recipe.Name = newName;

            Console.WriteLine("Enter the new number of steps:");
            int newNumberSteps = int.Parse(Console.ReadLine());
            if (!inputValidator.IsValidNumberOfSteps(newNumberSteps))
            {
                Console.WriteLine("Invalid number of steps. Please try again.");
                return;
            }
            recipe.NumberSteps = newNumberSteps;

            Console.WriteLine("Enter the new number of ingredients:");
            int newNumberIngreds = int.Parse(Console.ReadLine());
            if (!inputValidator.IsValidNumberOfIngredients(newNumberIngreds))
            {
                Console.WriteLine("Invalid number of ingredients. Please try again.");
                return;
            }
            recipe.NumberIngreds = newNumberIngreds;

            for (int i = 0; i < newNumberIngreds; i++)
            {
                Console.WriteLine($"Enter the new name of ingredient {i + 1}:");
                string newIngredName = Console.ReadLine();
                if (!inputValidator.IsValidIngredientName(newIngredName))
                {
                    Console.WriteLine("Invalid ingredient name. Please try again.");
                    return;
                }
                recipe.IngredName[i] = newIngredName;

                Console.WriteLine($"Enter the new quantity of ingredient {i + 1}:");
                double newQuantity = double.Parse(Console.ReadLine());
                if (!inputValidator.IsValidIngredientQuantity(newQuantity))
                {
                    Console.WriteLine("Invalid ingredient quantity. Please try again.");
                    return;
                }
                recipe.IngredQuan[i] = newQuantity.ToString();

                Console.WriteLine($"Enter the new unit of measurement for ingredient {i + 1}:");
                string newUnit = GetValidUnit();
                if (newUnit == null)
                {
                    return;
                }
                recipe.IngredUOM[i] = newUnit;
            }

            for (int i = 0; i < newNumberSteps; i++)
            {
                Console.WriteLine($"Enter the new description for step {i + 1}:");
                string newDesc = Console.ReadLine();
                if (!inputValidator.IsValidStepDescription(newDesc))
                {
                    Console.WriteLine("Invalid step description. Please try again.");
                    return;
                }
                recipe.Description[i] = newDesc;
            }

            Console.WriteLine("Recipe edited successfully!");
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// ViewRecipe methed to view all current recipes that are saved and use a factor to change the quantities
        /// </summary>

        //------------------------------------------------------------------------

        private void ViewRecipe()
        {
            List<Recipe> allRecipes = recipeManager.GetAllRecipes();
            if (allRecipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Here are all the available recipes:");
            for (int i = 0; i < allRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allRecipes[i].Name}");
            }

            Console.WriteLine("Enter the number of the recipe you want to view, or type 'cancel' to go back to the main menu:");
            string input = Console.ReadLine();

            if (input.ToLower() == "cancel")
            {
                return;
            }

            int index;
            if (!int.TryParse(input, out index) || index < 1 || index > allRecipes.Count)
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }

            Recipe originalRecipe = allRecipes[index - 1];

            // Create a copy of the original recipe
            Recipe recipe = new Recipe(originalRecipe.Name, originalRecipe.NumberSteps, originalRecipe.NumberIngreds, new List<string>(originalRecipe.IngredName), new List<string>(originalRecipe.IngredQuan), new List<string>(originalRecipe.IngredUOM), new List<string>(originalRecipe.Description));

            Console.WriteLine("Do you want to scale the recipe? (yes/no)");
            string scaleOption = Console.ReadLine();
            if (scaleOption.ToLower() == "yes")
            {
                Console.WriteLine("Enter the scaling factor:");
                double factor;
                if (!double.TryParse(Console.ReadLine(), out factor) || factor <= 0)
                {
                    Console.WriteLine("Invalid scaling factor. Please enter a positive number.");
                    return;
                }

                for (int i = 0; i < recipe.NumberIngreds; i++)
                {
                    double quantity = double.Parse(recipe.IngredQuan[i]);
                    quantity *= factor;
                    recipe.IngredQuan[i] = quantity.ToString();
                }

                Console.WriteLine("Recipe scaled successfully!");
            }

            // Display the properties of the recipe
            DisplayRecipe(recipe);

            if (scaleOption.ToLower() == "yes")
            {
                Console.WriteLine("Do you want to revert back to the original quantities? (yes/no)");
                string revertOption = Console.ReadLine();
                if (revertOption.ToLower() == "yes")
                {
                    // Revert back to the original recipe
                    recipe = originalRecipe;
                    Console.WriteLine("Reverted back to the original quantities.");
                    DisplayRecipe(recipe);
                }
            }
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// DisplayRecipe used in the ViewRecipe method for the two conditions that can occur inside the ViewRecipe method
        /// </summary>
        /// <param name="recipe"></param>

        //------------------------------------------------------------------------

        private void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine($"Recipe Name: {recipe.Name}");
            Console.WriteLine($"Number of Steps: {recipe.NumberSteps}");
            Console.WriteLine($"Number of Ingredients: {recipe.NumberIngreds}");

            Console.WriteLine("Ingredients:");
            for (int i = 0; i < recipe.NumberIngreds; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}: {recipe.IngredName[i]}, {recipe.IngredQuan[i]} {recipe.IngredUOM[i]}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.NumberSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}: {recipe.Description[i]}");
            }
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// GetValidUnit uses the InputValidator class to retrive the correct value for unit of measurement when adding a new recipe 
        /// </summary>
        /// <returns></returns>

        //------------------------------------------------------------------------

        private string GetValidUnit()
        {
            string unit = Console.ReadLine();

            if (inputValidator.IsValidIngredientUnit(ref unit))
            {
                return unit;
            }
            else
            {
                Console.WriteLine("Invalid unit of measurement. Please try again.");
                return null;
            }
        }
        
        //------------------------------------------------------------------------
    }
}

//---------------------------------------------------end-------------------------------------------------------
