namespace C_Practice_modul_12_part_02_ua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe reciple1 = new Recipe("reciple1");
            Recipe reciple2 = new Recipe("reciple2");
            RecipeManager manager = new RecipeManager();
            manager.AddRecipe(reciple1);
            manager.AddRecipe(reciple2);
            manager.RemoveRecipe("reciple1");
            manager.ShowRecipes();
            Console.ReadLine();
        }
    }
}
