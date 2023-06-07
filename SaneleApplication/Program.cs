using System;
using System.Collections.Generic;
using System.Linq;

delegate void notify(Recipe recipe);
namespace SaneleApplication
{
    internal class Program : Recipe
    {
        private static readonly List<string> foodGroups = new List<string> { "Fruit And Veg", "Protein", "Starch", "Dairy", "Fat" };

        static void CaloryNotification(Recipe recipe)
        {
            int totalCalories = recipe.CalculateTotalCalories();
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: The total calories of this recipe exceed 300!");
            }
            Console.ResetColor();
        }
        static void ProcessRecipe(Recipe recipe)
        {
            notify n1 = new notify(CaloryNotification);
            while (true)
            {
                Console.WriteLine("\n-------------------------------------" +
                    "\nChoose an option from below:\n 1 - Add ingredient(s)\n 2 - Add step\n 3 - Display the recipe\n 4 - Scale the recipe\n " +
                    "5 - Reset quantities to original values\n 6 - Clear all the data\n 7 - Return to main menu\n" +
                    "-------------------------------------");

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
                        Console.WriteLine("Enter the number of calories for the ingredient:");
                        int iCalories = int.Parse(Console.ReadLine());

                        Console.WriteLine("Select the food group for the ingredient:");
                        for (int i = 0; i < foodGroups.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {foodGroups[i]}");
                        }
                        int foodGroupSelection = int.Parse(Console.ReadLine());
                        string iFoodGroup = foodGroups[foodGroupSelection - 1];

                        recipe.AddIngredient(iName, iQuantity, ingredientUnit, iCalories, iFoodGroup);
                        n1(recipe);
                        break;

                    case 2:
                        Console.WriteLine("Enter step description:");
                        string step = Console.ReadLine();
                        recipe.AddStep(step);
                        break;

                    case 3:

                        Console.WriteLine("Enter the name of the recipe to display:");
                        string name = Console.ReadLine();
                        recipe.DisplayRecipe(name);
                        n1(recipe);
                        break;

                    case 4:
                        Console.WriteLine("Enter a factor to scale the ingredients by:");
                        double scale = double.Parse(Console.ReadLine());
                        recipe.ScaleTheRecipe(scale);
                        break;

                    case 5:
                        recipe.RequestReset();
                        break;

                    case 6:
                        recipe.ClearData();
                        break;

                    case 7:
                        Console.WriteLine("Returning to the main menu...");
                        return;

                    default:
                        Console.WriteLine("That selection does not exist.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your recipe application Sanele.");//Welcome the user of the application
            Dictionary<string, Recipe> recipeBook = new Dictionary<string, Recipe>(); // Dictionary to store recipes

            while (true)
            {
                Console.WriteLine("\n-------------------------------------" +
                    "\nChoose an option from below:\n 1 - Create a new recipe\n 2 - Select a recipe\n 3 - Exit\n" +
                    "-------------------------------------");

                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        //the following option allows the user to enter the name of the recipe
                        Console.WriteLine("Enter the name of the recipe:");
                        string recipeName = Console.ReadLine();
                        Recipe newRecipe = new Recipe();
                        recipeBook.Add(recipeName, newRecipe);
                        Console.WriteLine("Recipe '{0}' created.", recipeName);
                        break;

                        /*the following option allows the user to select a recipe to process, the user will be notified if the entered recipe does not exist*/
                    case 2:
                        if (recipeBook.Count == 0)
                        {
                            Console.WriteLine("No recipes available in the database. Please create a recipe first before continuing.");
                        }
                        else
                        {
                            Console.WriteLine("Available Recipes:");

                            /*Sorting method amended from learn.microsoft website*/
                            /*https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?redirectedfrom=MSDN&view=net-7.0#System_Collections_Generic_List_1_Sort_System_Comparison__0__*/
                            
                            var sortedRecipeNames = recipeBook.Keys.OrderBy(name => name); //lambda expression to sort the names in alphabetical order 

                            foreach (string availableRecipe in sortedRecipeNames) //for each to print out sorted names
                            {
                                Console.WriteLine("- " + availableRecipe);
                            }

                            Console.WriteLine("\nEnter the name of the recipe to select:");
                            string selectedRecipe = Console.ReadLine();

                            if (recipeBook.ContainsKey(selectedRecipe))
                            {
                                Recipe recipe = recipeBook[selectedRecipe];
                                ProcessRecipe(recipe);
                            }
                            else
                            {
                                Console.WriteLine("Recipe '{0}' does not exist.", selectedRecipe);
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("That selection does not exist.");
                        break;
                }
            }

        }
    }

    
}
