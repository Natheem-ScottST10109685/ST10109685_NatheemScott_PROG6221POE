using NatheemScott_ST10109685_Prog6221_POE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ST10109685_NatheemScott_PROG6221_POEPart2
{
    //--------------------------------------------------------------------------------------------------------------------------------------//
    // Recipe Class
    internal class Recipe
    {
        private List<Recipe> recipes = new List<Recipe>();

        private SpeechSynthesizer SayThis = new SpeechSynthesizer();
        private SoundPlayer musicPlayer;

        public List<Ingredients> Ingredients { get; private set; } = new List<Ingredients>();
        public List<string> Steps { get; private set; } = new List<string>();
        public string Name { get; private set; }

        //--------------------------------------------------------------------------------------------------------------------------------------//
        // A speak synthesis used for blind people maybe using the app
        public void RunMe()
        {
            SayThis.Speak("Welcome to Senele's Recipe App");
            SayThis.Speak("Hello User, please select one of the options that will appear below.");
            SayThis.Speak("Select 7 to exit or close the app entirely");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Music class Thank you Chatgpt XD
        public void Music()
        {
            string musicFilePath = @"C:\Users\Natheem Scott\Desktop\ST10109685_NatheemScott_PROG6221_POEPart2\Songs\Lullaby.wav";
            musicPlayer = new SoundPlayer(musicFilePath); // Create a new SoundPlayer instance
            musicPlayer.PlayLooping(); // Play the music in a loop
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to Add Recipes
        public void AddRecipe()
        {
            SayThis.Speak("Adding a new recipe.");
            Recipe newRecipe = new Recipe();
            Console.WriteLine("Enter the name of the recipe:");
            newRecipe.Name = Console.ReadLine();
            newRecipe.AddIngredients();
            newRecipe.AddSteps();
            recipes.Add(newRecipe);
            Console.WriteLine("Recipe added successfully");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to view all recipes
        public void ViewAllRecipes()
        {
            SayThis.Speak("Viewing all recipes.");
            if (recipes.Count == 0)
            {
                Console.WriteLine("0 recipes found");
                SayThis.Speak("I'm sorry there is no recipes found. Please select number 1 and add a recipe");
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                recipe.DisplayRecipe();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to search for recipes containing a keyword
        public void SearchForRecipe()
        {
            Console.WriteLine("Enter keyword to search for:");
            SayThis.Speak("Enter keyword to search for");
            string keyword = Console.ReadLine();

            bool found = false;
            foreach (var recipe in recipes)
            {
                if (recipe.ContainsKeyword(keyword))
                {
                    recipe.DisplayRecipe();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No recipes found containing the keyword.");
                SayThis.Speak("I'm sorry there is no recipes found. Please select number 1 and add a recipe");
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to delete all recipes
        public void DeleteAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found to delete.");
                SayThis.Speak("No recipes found to delete");
                SayThis.Speak("I'm sorry there is no recipes to delete. Please select number 1 and add a recipe");
                return;
            }

            recipes.Clear();
            SayThis.Speak("All recipes have been deleted.");
            Console.WriteLine("All recipes have been deleted.");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to scale all recipes
        public void ScaleRecipes(double scalingFactor)
        {
            foreach (var recipe in recipes)
            {
                recipe.ScaleRecipe(scalingFactor);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to add ingredients to the recipe
        public void AddIngredients()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter name of ingredient {i + 1}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter quantity of ingredient {i + 1}:");
                double quantity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Enter unit of measurement for ingredient {i + 1}:");
                string unit = Console.ReadLine();
                Ingredients.Add(new Ingredients(name, quantity, unit));
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to add steps to the recipe
        public void AddSteps()
        {
            Steps.Clear(); // Clear the existing steps

            Console.WriteLine("Enter the steps (press 'q' to quit):");
            string step;
            do
            {
                step = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(step) && step.ToLower() != "q")
                    Steps.Add(step);
            } while (step.ToLower() != "q");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to check if the recipe contains a keyword
        public bool ContainsKeyword(string keyword)
        {
            foreach (var ingredient in Ingredients)
            {
                if (ingredient.Name.Contains(keyword))
                    return true;
            }

            foreach (var step in Steps)
            {
                if (step.Contains(keyword))
                    return true;
            }

            return false;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Method to reset quantities
        public void ResetQuantities()
        {
            // Reset quantities to their original values
            foreach (var ingredient in Ingredients)
            {
                // Assuming original quantities are stored in a separate property
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------//
        // Stops the music
        public void StopMusic()
        {
            if (musicPlayer != null)
            {
                musicPlayer.Stop(); // Stop the music
            }
        }
    }
}
//------------------------------------------------------END OF FILE----------------------------------------------------------//