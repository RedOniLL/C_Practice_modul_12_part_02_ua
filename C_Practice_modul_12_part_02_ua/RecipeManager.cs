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

       
    }
}
