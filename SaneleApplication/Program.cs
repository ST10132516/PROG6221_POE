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



    }
}
