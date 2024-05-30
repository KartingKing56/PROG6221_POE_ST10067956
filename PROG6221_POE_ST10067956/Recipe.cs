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
        /// <param name="ingredGroup"></param>
        /// <param name="ingredCalory"></param>
        /// <param name="totalCalory"></param>

        //------------------------------------------------------------------------

        public Recipe
            (
            string name, 
            int numberSteps, 
            int numberIngreds, 
            List<string> ingredName, 
            List<string> ingredQuan, 
            List<string> ingredUOM, 
            List<string> description, 
            List<string> ingredGroup, 
            List<int> ingredCalory, 
            double totalCalory
            )

        {
            Name = name;
            NumberSteps = numberSteps;
            NumberIngreds = numberIngreds;
            IngredName = ingredName;
            IngredQuan = ingredQuan;
            IngredUOM = ingredUOM;
            Description = description;
            IngredGroup = ingredGroup;
            IngredCalory = ingredCalory;
            TotalCalory = totalCalory;
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
        public List<string> IngredGroup { get; set; }
        public List<int> IngredCalory { get; set; }
        public double TotalCalory { get; set; }

        //------------------------------------------------------------------------
    }
}

//---------------------------------------------------end-------------------------------------------------------