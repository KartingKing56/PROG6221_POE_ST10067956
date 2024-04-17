using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_ST10067956
{
    public class Recipe
    {
        //------------------------------------------------------------------------

        /// <summary>
        /// Contructor for the Recipe class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numberSteps"></param>
        /// <param name="numberIngreds"></param>
        /// <param name="ingredName"></param>
        /// <param name="ingredQuan"></param>
        /// <param name="ingredUOM"></param>
        /// <param name="description"></param>

        //------------------------------------------------------------------------

        public Recipe(string name, int numberSteps, int numberIngreds, List<string> ingredName, List<string> ingredQuan, List<string> ingredUOM, List<string> description)
        {
            Name = name;
            NumberSteps = numberSteps;
            NumberIngreds = numberIngreds;
            IngredName = ingredName;
            IngredQuan = ingredQuan;
            IngredUOM = ingredUOM;
            Description = description;
        }

        //------------------------------------------------------------------------

        /// <summary>
        /// All the getters and setters for all the variables in this class
        /// </summary>

        //------------------------------------------------------------------------

        public string Name { get; set; }
        public int NumberSteps { get; set; }
        public int NumberIngreds { get; set; }
        public List<string> IngredName { get; set; }
        public List<string> IngredQuan { get; set; }
        public List<string> IngredUOM { get; set; }
        public List<string> Description { get; set; }

        //------------------------------------------------------------------------
    }
}

//---------------------------------------------------end-------------------------------------------------------