using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10109685_NatheemScott_PROG6221_POEPart2
{
    internal class Program
    {
        /// <summary>
        /// This is the main method that calls from the Recipe. The case and switch calls the recipeManager to run all the
        /// related methods. The RunMe() and Music() has the speech greeting the user and asking to select an option; and the
        /// Music() plays a song in the background. When scaling the quantities be advised to press , instead of . I am trying
        /// to fix it but that's what works.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;

            Recipe recipeManager = new Recipe();
            recipeManager.RunMe();
            recipeManager.Music();

            //--------------------------------------------------------------------------------//
            // Loop indefinitely until the user chooses to exit
            while (true)
            {
                Console.WriteLine("Welcome to Senele's Recipe App");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. View all recipes");
                Console.WriteLine("3. Display a recipe");
                Console.WriteLine("4. Search for a recipe");
                Console.WriteLine("5. Delete all recipes");
                Console.WriteLine("6. Scale the recipe");
                Console.WriteLine("7. Reset quantities");
                Console.WriteLine("8. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        recipeManager.AddRecipe();
                        break;
                    case 2:
                        recipeManager.ViewAllRecipes();
                        break;
                    case 3:
                        recipeManager.DisplayRecipe();
                        break;
                    case 4:
                        recipeManager.SearchForRecipe();
                        break;
                    case 5:
                        recipeManager.DeleteAllRecipes();
                        break;
                    case 6:
                        double scalingFactor;
                        while (true)
                        {
                            Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                            if (double.TryParse(Console.ReadLine(), out scalingFactor) && (scalingFactor == 0.5 || scalingFactor == 2 || scalingFactor == 3))
                            {
                                recipeManager.ScaleRecipes(scalingFactor);
                                Console.WriteLine("Recipes scaled successfully.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid scaling factor (0.5, 2, or 3).");
                            }
                        }
                        break;
                    case 7:
                        recipeManager.ResetQuantities();
                        Console.WriteLine("Quantities reset to original values for all recipes.");
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
//-----------------End Of File--------------------------//