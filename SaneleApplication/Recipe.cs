using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Recipe
{
    private List<Ingredient> ingredientsList;
    private List<string> stepsList;
    public Recipe()
    {
        ingredientsList = new List<Ingredient>();
        stepsList = new List<string>();
    }

    /*Method to add individual ingredients*/
    public void AddIngredient(string name, double quantity, string unit, int foodCalories, string foodGroup)
    {
        Ingredient ingredient = new Ingredient { name = name, quantity = quantity, unit = unit, foodCalories = foodCalories, foodGroup = foodGroup };
        ingredientsList.Add(ingredient);
    }

    /*Below method allows the user to add steps*/
    public void AddStep(string step)
    {
        stepsList.Add(step);
    }

    /*This method displays all the details about the current recipe*/
    public void DisplayRecipe(string name)
    {

        if (!ingredientsList.Any() && !stepsList.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Recipe '{0}' is empty.", name);
            return;
        }

        Console.WriteLine("Recipe: {0}", name);

        Console.WriteLine("Ingredients:");
        foreach (Ingredient ingredient in ingredientsList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("- {0} {1} of {2} belongs to the {3} Food Group, which has a total of {4} calories",
                ingredient.quantity, ingredient.unit, ingredient.name, ingredient.foodGroup, ingredient.foodCalories);
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Steps:");
        for (int i = 0; i < stepsList.Count; i++)
        {
            Console.WriteLine("{0}. {1}", i + 1, stepsList[i]);
        }

        int totalCalories = ingredientsList.Sum(ingredient => ingredient.foodCalories);
        Console.WriteLine("Total Calories: {0}", totalCalories);
        Console.ResetColor();
 
    }

    /*This method allows the user to scale the recipe using a factor of their choosing*/
    public void ScaleTheRecipe(double factor)
    {
        foreach (Ingredient ingredient in ingredientsList)
        {
            ingredient.quantity *= factor;
        }
    }

    /*Method to reset the quantity value*/
    public void RequestReset()
    {
        foreach (Ingredient ingredient in ingredientsList)
        {
            ingredient.quantity /= 2; // assuming quantities are scaled up by a factor of 2 initially
        }
    }

    /*This method clears the contents of the lists*/
    public void ClearData()
    {
        ingredientsList.Clear();
        stepsList.Clear();
    }

    /*Method to calculate the total calories in the recipe*/
    public int CalculateTotalCalories(string foodGroup = null)
    {
        int totalCalories = 0;

        foreach (Ingredient ingredient in ingredientsList)
        {
            if (foodGroup == null || ingredient.foodGroup == foodGroup)
            {
                totalCalories += ingredient.foodCalories;
            }
        }

        return totalCalories;
    }
}
class Ingredient
{
    public string name;
    public double quantity;
    public string unit;
    public int foodCalories;
    public string foodGroup;
}
