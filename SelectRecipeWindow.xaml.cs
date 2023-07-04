using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace SaneleGUI
{
    public partial class SelectRecipeWindow : Window
    {
        private Recipe selectedRecipe;
        private List<Recipe> selectedRecipes = new List<Recipe>();

        public SelectRecipeWindow()
        {
            InitializeComponent();
            cmbRecipes.ItemsSource = RecipeManager.Recipes;
        }

        private void cmbRecipes_SelectionChanged(object sender, RoutedEventArgs e)
        {
            selectedRecipe = cmbRecipes.SelectedItem as Recipe;
        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                StringBuilder details = new StringBuilder();
                details.AppendLine($"Recipe Name: {selectedRecipe.Name}\n");
                details.AppendLine("Ingredients:");
                double totalCalories = 0;
                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    details.AppendLine($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.Unit}) - {ingredient.Calories} calories");
                    totalCalories += ingredient.Calories;
                }
                details.AppendLine($"\nTotal Calories: {totalCalories} calories");
                details.AppendLine("\nSteps:");
                int stepCount = 1;
                foreach (RecipeStep step in selectedRecipe.Steps)
                {
                    details.AppendLine($"Step {stepCount++}: {step.Description}");
                }

                RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow(details.ToString());
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error");
            }
        }

        private void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                double scalingFactor;
                if (double.TryParse(txtScalingFactor.Text, out scalingFactor))
                {
                    if (scalingFactor == 0.5 || scalingFactor == 2 || scalingFactor == 3)
                    {
                        Recipe scaledRecipe = ScaleRecipe(selectedRecipe, scalingFactor);

                        StringBuilder details = new StringBuilder();
                        details.AppendLine($"Scaled Recipe Name: {scaledRecipe.Name}\n");
                        details.AppendLine("Ingredients:");
                        double totalCalories = 0;
                        foreach (Ingredient ingredient in scaledRecipe.Ingredients)
                        {
                            details.AppendLine($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.Unit}) - {ingredient.Calories} calories");
                            totalCalories += ingredient.Calories;
                        }
                        details.AppendLine($"\nTotal Calories: {totalCalories} calories");
                        details.AppendLine("\nSteps:");
                        int stepCount = 1;
                        foreach (RecipeStep step in scaledRecipe.Steps)
                        {
                            details.AppendLine($"Step {stepCount++}: {step.Description}");
                        }

                        RecipeDetailsWindow detailsWindow = new RecipeDetailsWindow(details.ToString());
                        detailsWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid scaling factor. Please enter 0.5, 2, or 3.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid scaling factor. Please enter a valid number.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error");
            }
        }

        private Recipe ScaleRecipe(Recipe recipe, double scalingFactor)
        {
            List<Ingredient> scaledIngredients = new List<Ingredient>();
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                double scaledQuantity = ingredient.Quantity * scalingFactor;
                double scaledCalories = ingredient.Calories * scalingFactor;
                Ingredient scaledIngredient = new Ingredient(ingredient.Name, scaledQuantity, ingredient.Unit, scaledCalories, ingredient.FoodGroup);
                scaledIngredients.Add(scaledIngredient);
            }

            return new Recipe($"{scalingFactor}x {recipe.Name}", scaledIngredients, recipe.Steps);
        }

        private void txtScalingFactor_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Allow only digits and a dot for decimal input
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != ".")
            {
                e.Handled = true;
            }
        }

        private void btnAddToMenu_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                selectedRecipes.Add(selectedRecipe);
                MessageBox.Show("Recipe added to the menu.", "Success");
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error");
            }
        }

        private void btnCreateMenu_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipes.Count > 0)
            {
                Dictionary<string, double> foodGroupPercentages = CalculateFoodGroupPercentages(selectedRecipes);

                // Create a PieChart to display the food group percentages
                SeriesCollection seriesCollection = new SeriesCollection();
                foreach (var kvp in foodGroupPercentages)
                {
                    seriesCollection.Add(new PieSeries
                    {
                        Title = kvp.Key,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(kvp.Value) },
                        DataLabels = true
                    });
                }

                PieChart chart = new PieChart
                {
                    Series = seriesCollection,
                    LegendLocation = LegendLocation.Right // Set the legend position here
                };

                Window chartWindow = new Window
                {
                    Title = "Menu Food Group Percentages",
                    Content = chart,
                    Width = 600,
                    Height = 400
                };

                chartWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select recipes to include in the menu.", "Error");
            }
        }

        private Dictionary<string, double> CalculateFoodGroupPercentages(List<Recipe> recipes)
        {
            Dictionary<string, double> foodGroupCounts = new Dictionary<string, double>();

            foreach (Recipe recipe in recipes)
            {
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (!foodGroupCounts.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupCounts[ingredient.FoodGroup] = 0;
                    }

                    foodGroupCounts[ingredient.FoodGroup] += ingredient.Quantity;
                }
            }

            double totalQuantity = 0;
            foreach (var kvp in foodGroupCounts)
            {
                totalQuantity += kvp.Value;
            }

            Dictionary<string, double> foodGroupPercentages = new Dictionary<string, double>();
            foreach (var kvp in foodGroupCounts)
            {
                double percentage = kvp.Value / totalQuantity * 100;
                foodGroupPercentages[kvp.Key] = Math.Round(percentage, 2);
            }

            return foodGroupPercentages;
        }
    }

    public class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow(string details)
        {
            Title = "Recipe Details";
            Width = 800;
            Height = 600;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);

            // Create a TextBlock to display the recipe details
            TextBlock textBlock = new TextBlock();
            textBlock.Text = details;
            textBlock.Margin = new Thickness(0, 0, 0, 10);
            stackPanel.Children.Add(textBlock);

            // Create a FlowDocumentScrollViewer to display the recipe steps with checkboxes
            FlowDocumentScrollViewer documentViewer = new FlowDocumentScrollViewer();
            documentViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.FontSize = 14;

            // Create a Paragraph for each step
            int stepCount = 1;
            foreach (string line in details.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                if (line.StartsWith("Step"))
                {
                    Paragraph paragraph = new Paragraph();
                    paragraph.Margin = new Thickness(0, 0, 0, 5);

                    // Create a CheckBox for the step
                    CheckBox checkBox = new CheckBox();
                    checkBox.Content = line;
                    checkBox.Tag = stepCount++;
                    checkBox.Margin = new Thickness(5);
                    checkBox.Checked += StepCheckBox_Checked;
                    checkBox.Unchecked += StepCheckBox_Unchecked;

                    // Add the CheckBox to the Paragraph
                    paragraph.Inlines.Add(checkBox);

                    // Add the Paragraph to the FlowDocument
                    flowDocument.Blocks.Add(paragraph);
                }
            }

            documentViewer.Document = flowDocument;
            stackPanel.Children.Add(documentViewer);

            Content = stackPanel;
        }

        private void StepCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                // Add styling to indicate completion of the step
                checkBox.FontStyle = FontStyles.Italic;
                checkBox.Foreground = SystemColors.GrayTextBrush;
            }
        }

        private void StepCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                // Remove styling
                checkBox.FontStyle = FontStyles.Normal;
                checkBox.ClearValue(ForegroundProperty);
            }
        }
    }
}
