namespace C_Practice_modul_12_part_02_ua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            recipeManager.AddRecipe(new Recipe(
                "Spaghetti Carbonara",
                "Italian",
                new List<string> { "Spaghetti", "Guanciale", "Egg", "Pecorino Romano Cheese", "Black Pepper" },
                "20 minutes",
                "1. Cook spaghetti. 2. Fry guanciale. 3. Mix egg and cheese. 4. Combine all ingredients."
            ));
            recipeManager.AddRecipe(new Recipe(
                "Sushi",
                "Japanese",
                new List<string> { "Rice", "Nori", "Fish", "Vegetables", "Soy Sauce" },
                "30 minutes",
                "1. Cook rice. 2. Prepare fillings. 3. Roll sushi."
            ));

            recipeManager.SaveRecipesToFile("Recipes.txt");

            recipeManager.RemoveRecipe("Sushi");

            Recipe updatedRecipe = new Recipe(
                "Spaghetti Carbonara",
                "Italian",
                new List<string> { "Spaghetti", "Guanciale", "Egg", "Pecorino Romano Cheese", "Black Pepper", "Parsley" },
                "20 minutes",
                "1. Cook spaghetti. 2. Fry guanciale. 3. Mix egg and cheese. 4. Combine all ingredients. 5. Garnish with parsley."
            );
            recipeManager.UpdateRecipe("Spaghetti Carbonara", updatedRecipe);

            recipeManager.GenerateReportByCuisine("Italian", true, "ItalianRecipes.txt");
            recipeManager.GenerateReportByCookingTime("20 minutes", true, "FastRecipes.txt");

            recipeManager.LoadRecipesFromFile("Recipes.txt");

            recipeManager.ShowRecipes();
        }
    }
}
