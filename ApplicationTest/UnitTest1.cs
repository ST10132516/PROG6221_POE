namespace ApplicationTest
{
    [TestFixture]
    public class Tests
    {

        [Test]
        /*This method just tests if the total calories are added up correctly*/
        public void CalculateTotalCalories_ReturnsCorrectTotalCalories_Normal()
        {

            //Arranging the tests
            Recipe recipe = new Recipe();
            recipe.AddIngredient("Eggs", 2, "pieces", 50, "Poultry");
            recipe.AddIngredient("Bacon", 50, "grams", 120, "Meat");
            recipe.AddIngredient("Bread", 2, "pieces", 10, "Baked goods");
            recipe.AddIngredient("Butter", 20, "grams", 95, "Dairy");

            //declaration
            int totalCalories = recipe.CalculateTotalCalories();

            //Assert test
            Assert.AreEqual(275, totalCalories);
        }
        [Test]
        /*The following method just verifies that if all ingredients have 0 calories then the total calories must equal to zero as well*/
        public void CalculateTotalCalories_ZeroCaloriesEntered_ReturnsZero()
        {
            Recipe recipe = new Recipe();
            // Arranging the tests
            recipe.AddIngredient("Eggs", 2, "pieces", 0, "Poultry");
            recipe.AddIngredient("Bacon", 50, "grams", 0, "Meat");
            recipe.AddIngredient("Bread", 2, "pieces", 0, "Baked goods");
            recipe.AddIngredient("Butter", 20, "grams", 0, "Dairy");

            // declaration
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }
        [Test]
        /*This method tests whether the calories in a specific food group add up to the total*/
        public void CalculateTotalCalories_OneFoodGroup_ReturnsTotal()
        {
            Recipe recipe = new Recipe();
            // Arranging the tests
            recipe.AddIngredient("Eggs", 2, "pieces", 50, "Protein");
            recipe.AddIngredient("Bacon", 50, "grams", 120, "Protein");
            recipe.AddIngredient("Bread", 2, "pieces", 10, "Starch");
            recipe.AddIngredient("Butter", 20, "grams", 95, "Dairy");
            recipe.AddIngredient("Chicken Breasts", 1, "pieces", 50, "Protein");

            // declaration
            int totalCalories = recipe.CalculateTotalCalories("Protein");

            // Assert
            Assert.AreEqual(220, totalCalories);
        }
    }
}