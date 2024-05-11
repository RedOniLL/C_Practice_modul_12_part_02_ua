using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Practice_modul_12_part_02_ua
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public string Cuisine { get; set; }
        public List<string> Ingredients { get; set; }
        public string CookingTime { get; set; }
        public string PreparationSteps { get; set; }

        public Recipe(string recipeName, string cuisine, List<string> ingredients, string cookingTime, string preparationSteps)
        {
            RecipeName = recipeName;
            Cuisine = cuisine;
            Ingredients = ingredients;
            CookingTime = cookingTime;
            PreparationSteps = preparationSteps;
        }


        public Recipe()
        {
            RecipeName = "Default Recipe";
            Cuisine = "Default Cuisine";
            Ingredients = new List<string>() { "Default Ingredient" };
            CookingTime = "Default Cooking Time";
            PreparationSteps = "Default Preparation Steps";
        }

        public Recipe(string recipeName)
        {
            RecipeName = recipeName;
            Cuisine = "Default Cuisine";
            Ingredients = new List<string>() { "Default Ingredient" };
            CookingTime = "Default Cooking Time";
            PreparationSteps = "Default Preparation Steps";
        }
        public void DisplayRecipeDetails()
        {
            Console.WriteLine($"Recipe Name: {RecipeName}");
            Console.WriteLine($"Cuisine: {Cuisine}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine($"Cooking Time: {CookingTime}");
            Console.WriteLine("Preparation Steps:");
            Console.WriteLine(PreparationSteps);
        }
    }
}
