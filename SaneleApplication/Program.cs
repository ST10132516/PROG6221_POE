using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaneleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Ingredient
    {
        public string name;
        public double quantity;
        public string unit;
    }

    class Recipe
    {
        private Ingredient[] ingredientsArr;
        private string[] stepsArr;
        private int numIngredients;
        private int numSteps;
        public Recipe()
        {
            ingredientsArr = new Ingredient[10]; // start with capacity for 10 ingredients
            stepsArr = new string[10]; // start with capacity for 10 steps
            numIngredients = 0;
            numSteps = 0;
        }
        /*Method to add individual ingredients*/
        public void AddIngredient(string name, double quantity, string unit)
        {
            if (numIngredients >= ingredientsArr.Length)
            {
                Array.Resize(ref ingredientsArr, ingredientsArr.Length * 2); // double the capacity if adding more than one ingredient
            }
            Ingredient ingredient = new Ingredient { name = name, quantity = quantity, unit = unit };
            ingredientsArr[numIngredients++] = ingredient; //increment the number of ingredients as more are added
        }



    }
}
