using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace SaneleGUI
{
    public partial class CreateRecipeWindow : Window, INotifyPropertyChanged
    {
        private List<Ingredient> ingredients;
        private List<RecipeStep> steps;
        private bool isRecipeNameEntered;

        public bool IsRecipeNameEntered
        {
            get { return isRecipeNameEntered; }
            set
            {
                isRecipeNameEntered = value;
                OnPropertyChanged(nameof(IsRecipeNameEntered));
            }
        }

        public CreateRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<RecipeStep>();
            DataContext = this;
        }

        private void EnterRecipeName_Click(object sender, RoutedEventArgs e)
        {
            // Add validation for the recipe name if necessary
            IsRecipeNameEntered = !string.IsNullOrWhiteSpace(txtRecipeName.Text);
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve ingredient information from textboxes
            string name = txtIngredientName.Text;
            double quantity = double.Parse(txtIngredientQuantity.Text);
            string unit = txtIngredientUnit.Text;
            int calories = int.Parse(txtIngredientCalories.Text);
            string foodGroup = ((ComboBoxItem)cmbFoodGroup.SelectedItem).Content.ToString();

            // Create new ingredient object
            Ingredient ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);

            // Calculate current total calories
            double currentTotalCalories = 0;
            foreach (Ingredient existingIngredient in ingredients)
            {
                currentTotalCalories += existingIngredient.Calories;
            }

            // Check if adding the new ingredient will exceed 300 calories
            if (currentTotalCalories + ingredient.Calories > 300)
            {
                MessageBox.Show("Warning: Adding this ingredient will exceed 300 calories!");
            }

            // Add ingredient to the ingredients list
            ingredients.Add(ingredient);

            // Clear textboxes for the next input
            txtIngredientName.Clear();
            txtIngredientQuantity.Clear();
            txtIngredientUnit.Clear();
            txtIngredientCalories.Clear();
            cmbFoodGroup.SelectedIndex = -1;
        }


        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve step description from textbox
            string description = txtStepDescription.Text;

            // Create new recipe step object
            RecipeStep step = new RecipeStep(description);

            // Add step to the steps list
            steps.Add(step);

            // Clear textbox for the next input
            txtStepDescription.Clear();
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Calculate total calories
            double totalCalories = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            // Check if total calories exceed 300
            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: Total calories exceed 300!");
            }

            lblTotalCalories.Content = "Total Calories: " + totalCalories;

            // Store the recipe and its details in corresponding collections
            Recipe recipe = new Recipe(txtRecipeName.Text, new List<Ingredient>(ingredients), new List<RecipeStep>(steps));
            RecipeManager.AddRecipe(recipe);

            // Clear textboxes and reset lists for the next recipe
            ClearFields();

            // Notify the user that the current recipe has been saved and prompt for the next recipe name
            MessageBox.Show("Recipe saved. Please enter the name of the next recipe if you wish to add another one.");
        }



        private void ClearFields()
        {
            txtRecipeName.Clear();
            txtIngredientName.Clear();
            txtIngredientQuantity.Clear();
            txtIngredientUnit.Clear();
            txtIngredientCalories.Clear();
            cmbFoodGroup.SelectedIndex = -1;
            txtStepDescription.Clear();

            ingredients.Clear();
            steps.Clear();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    public class RecipeStep
    {
        public string Description { get; set; }

        public RecipeStep(string description)
        {
            Description = description;
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeStep> Steps { get; set; }

        public Recipe(string name, List<Ingredient> ingredients, List<RecipeStep> steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class RecipeManager
    {
        public static List<Recipe> Recipes { get; } = new List<Recipe>();

        public static void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
