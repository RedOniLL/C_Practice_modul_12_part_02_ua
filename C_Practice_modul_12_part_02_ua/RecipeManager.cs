using System;

namespace C_Practice_modul_12_part_02_ua
{
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(string recipeName)
        {
            recipes.RemoveAll(r => r.RecipeName == recipeName);
        }

        public void UpdateRecipe(string recipeName, Recipe updatedRecipe)
        {
            for(int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].RecipeName == recipeName) { recipes[i] =  updatedRecipe; }
            }
        }

        public List<Recipe> SearchRecipesByIngredient(string ingredient)
        {
            return recipes.Where(r => r.Ingredients.Contains(ingredient)).ToList();
        }

        public List<Recipe> SearchRecipesByCategory(string cuisine)
        {
            return recipes.Where(r => r.Cuisine == cuisine).ToList();
        }

        public void ShowRecipes()
        {
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine("---------------------------");
                recipe.DisplayRecipeDetails();
            }
        }


        public void GenerateReportByCuisine(string cuisine, bool outputToConsole = true, string fileName = "")
        {
            var filteredRecipes = recipes.Where(r => r.Cuisine == cuisine).ToList();
            GenerateReport(filteredRecipes, $"Recipes Report for Cuisine: {cuisine}", outputToConsole, fileName);
        }

        public void GenerateReportByCookingTime(string cookingTime, bool outputToConsole = true, string fileName = "")
        {
            var filteredRecipes = recipes.Where(r => r.CookingTime == cookingTime).ToList();
            GenerateReport(filteredRecipes, $"Recipes Report for Cooking Time: {cookingTime}", outputToConsole, fileName);
        }

        public void GenerateReportByIngredient(string ingredient, bool outputToConsole = true, string fileName = "")
        {
            var filteredRecipes = recipes.Where(r => r.Ingredients.Contains(ingredient)).ToList();
            GenerateReport(filteredRecipes, $"Recipes Report for Ingredient: {ingredient}", outputToConsole, fileName);
        }

        public void GenerateReportByRecipeName(string recipeName, bool outputToConsole = true, string fileName = "")
        {
            var filteredRecipes = recipes.Where(r => r.RecipeName == recipeName).ToList();
            GenerateReport(filteredRecipes, $"Recipes Report for Recipe: {recipeName}", outputToConsole, fileName);
        }

        private void GenerateReport(List<Recipe> filteredRecipes, string reportTitle, bool outputToConsole, string fileName)
        {
            if (outputToConsole)
            {
                Console.WriteLine(reportTitle);
                Console.WriteLine("---------------------------------------------------");
                if (filteredRecipes.Any())
                {
                    foreach (var recipe in filteredRecipes)
                    {
                        recipe.DisplayRecipeDetails();
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No recipes found.");
                }
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                SaveReportToFile(filteredRecipes, fileName);
            }
        }

        private void SaveReportToFile(List<Recipe> filteredRecipes, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Recipe Report");
                writer.WriteLine("---------------------------------------------------");
                if (filteredRecipes.Any())
                {
                    foreach (var recipe in filteredRecipes)
                    {
                        writer.WriteLine($"Recipe Name: {recipe.RecipeName}");
                        writer.WriteLine($"Cuisine: {recipe.Cuisine}");
                        writer.WriteLine("Ingredients:");
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            writer.WriteLine($"- {ingredient}");
                        }
                        writer.WriteLine($"Cooking Time: {recipe.CookingTime}");
                        writer.WriteLine("Preparation Steps:");
                        writer.WriteLine(recipe.PreparationSteps);
                        writer.WriteLine();
                    }
                }
                else
                {
                    writer.WriteLine("No recipes found.");
                }
            }
        }

        public void SaveRecipesToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var recipe in recipes)
                {
                    writer.WriteLine($"Recipe Name: {recipe.RecipeName}");
                    writer.WriteLine($"Cuisine: {recipe.Cuisine}");
                    writer.WriteLine("Ingredients:");
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        writer.WriteLine($"- {ingredient}");
                    }
                    writer.WriteLine($"Cooking Time: {recipe.CookingTime}");
                    writer.WriteLine("Preparation Steps:");
                    writer.WriteLine(recipe.PreparationSteps);
                    writer.WriteLine();
                }
            }
        }

        public void LoadRecipesFromFile(string fileName)
        {
            recipes.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                Recipe recipe = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Recipe Name:"))
                    {
                        if (recipe != null)
                        {
                            recipes.Add(recipe);
                        }
                        recipe = new Recipe();
                        recipe.RecipeName = line.Substring("Recipe Name: ".Length);
                    }
                    else if (line.StartsWith("Cuisine:"))
                    {
                        recipe.Cuisine = line.Substring("Cuisine: ".Length);
                    }
                    else if (line.StartsWith("Ingredients:"))
                    {
                        recipe.Ingredients = new List<string>();
                    }
                    else if (line.StartsWith("- "))
                    {
                        recipe.Ingredients.Add(line.Substring(2));
                    }
                    else if (line.StartsWith("Cooking Time:"))
                    {
                        recipe.CookingTime = line.Substring("Cooking Time: ".Length);
                    }
                    else if (line.StartsWith("Preparation Steps:"))
                    {
                        recipe.PreparationSteps = line.Substring("Preparation Steps: ".Length);
                    }
                }
                if (recipe != null)
                {
                    recipes.Add(recipe);
                }
            }
        }
    }
}
