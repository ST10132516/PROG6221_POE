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
        /*Below method allows the user to add steps*/
        public void AddStep(string step)
        {
            if (numSteps >= stepsArr.Length)
            {
                Array.Resize(ref stepsArr, stepsArr.Length * 2); // double the capacity if needed
            }
            stepsArr[numSteps++] = step;
        }
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredientsArr)
            {
                if (ingredient != null)
                {
                    Console.WriteLine("- {0} {1} {2}", ingredient.quantity, ingredient.unit, ingredient.name);
                }
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, stepsArr[i]);
            }
        }
        public void ScaleTheRecipe(double factor)
        {
            foreach (Ingredient ingredient in ingredientsArr)
            {
                if (ingredient != null)
                {
                    ingredient.quantity *= factor;
                }
            }
        }



    }
}
