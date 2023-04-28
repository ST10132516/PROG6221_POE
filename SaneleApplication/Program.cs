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
            Console.WriteLine("Welcome to your recipe application Sanele.");//Welcome the user of the application
            Recipe r1 = new Recipe();

            while (true)
            {
                Console.WriteLine("\n-------------------------------------" +
                    "\nChoose an option from below:\n 1 - Add ingredient(s)\n 2 - Add step\n 3 - Display the recipe\n 4 - Scale the recipe\n " +
                    "5 - Reset quantities to original values\n 6 - Clear all the data\n 7 - exit\n" +
                    "-------------------------------------"); //list all available options to choose from
                int selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter name of the ingredient:");
                        string iName = Console.ReadLine();
                        Console.WriteLine("Enter the quantity for the ingredient:");
                        double iQuantity = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ingredient unit:");
                        string ingredientUnit = Console.ReadLine();
                        r1.AddIngredient(iName, iQuantity, ingredientUnit);
                        break;
                    case 2:
                        Console.WriteLine("Enter step description:");
                        string step = Console.ReadLine();
                        r1.AddStep(step);
                        break;

                    case 3:
                        r1.DisplayRecipe();
                        break;

                    case 4:
                        Console.WriteLine("Enter a factor to scale the ingredients by:");
                        double scale = double.Parse(Console.ReadLine());
                        r1.ScaleTheRecipe(scale);
                        break;

                    case 5:
                        r1.RequestReset();
                        break;

                    case 6:
                        r1.ClearData();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("That selection does not exist");
                        break;
                }
            }

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
        /*Method to reset the quantity value*/
        public void RequestReset()
        {
            foreach (Ingredient ingredient in ingredientsArr)
            {
                if (ingredient != null)
                {
                    ingredient.quantity /= 2; // assuming quantities are scaled up by a factor of 2 initially
                }
            }
        }

        /*This method clears the contenets of the arrays and resets values*/
        public void ClearData()
        {
            ingredientsArr = new Ingredient[10];
            stepsArr = new string[10];
            numIngredients = 0;
            numSteps = 0;
        }



    }
}
