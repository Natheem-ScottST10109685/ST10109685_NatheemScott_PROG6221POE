using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Recipe> AllRecipes { get; set; } = new List<Recipe>();

        /// <summary>
        /// Initializes the main window, updates the recipe list box, and adds default recipes.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            UpdateRecipesListBox(); 
            this.Loaded += MainWindow_Loaded; // Attach the Loaded event handler
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Check if there are no recipes and show a prompt if the list is empty
            if (AllRecipes.Count == 0)
            {
                MessageBox.Show("Please add a recipe if you want to proceed with the app!", "Senele's Recipe App", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            UpdateRecipesListBox();
        }

        /// <summary>
        /// Handles the click event of the Add button.
        /// Opens a new AddRecipe window to allow the user to add a new recipe.
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe add = new AddRecipe();
            add.Show();
            this.Close();
            UpdateRecipesListBox();
        }

        /// <summary>
        /// Handles the click event of the Display All button. Displays all recipes in the list box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecipesListBox();
        }

        /// <summary>
        /// Displays the specific recipes in the list box.
        /// </summary>
        /// <param name="recipes">The list of recipes to display.</param>
        private void btnDisplaySpecific_Click(object sender, RoutedEventArgs e)
        {
            SpecificRecipe spec = new SpecificRecipe();
            spec.Show();
            this.Close();
        }

        /// <summary>
        /// Displays the specific recipes in the list box.
        /// </summary>
        /// <param name="recipes">The list of recipes to display.</param>
        public void DisplaySpecificRecipes(List<Recipe> recipes)
        {
            lstboxAllRecipes.Items.Clear();
            foreach (var recipe in recipes)
            {
                lstboxAllRecipes.Items.Add(recipe.ToString());
            }
        }

        /// <summary>
        /// Handles the click event of the Reset button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            if (AllRecipes.Count == 0)
            {
                MessageBox.Show("Please add a recipe before scaling.");
                return;
            }

            Recipe selectedRecipe;

            if (lstboxAllRecipes.SelectedItem != null)
            {
                selectedRecipe = lstboxAllRecipes.SelectedItem as Recipe;
            }
            else if (AllRecipes.Count == 1)
            {
                selectedRecipe = AllRecipes[0];
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
                return;
            }

            Scale scaleWindow = new Scale(selectedRecipe);
            scaleWindow.ShowDialog();

            // Update the list box after scaling
            UpdateRecipesListBox();
        }

        private void btnPie_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipes = lstboxAllRecipes.Items.Cast<Recipe>().Where(r => r.IsSelected).ToList();
            if (selectedRecipes.Count == 0)
            {
                MessageBox.Show("Please select at least one recipe to create a menu.");
                return;
            }

            pieChart chart = new pieChart(selectedRecipes);
            chart.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the Clear button. Clears all recipes from the list box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            AllRecipes.Clear();
            lstboxAllRecipes.Items.Clear();
            MessageBox.Show("All recipes have been cleared.", "Recipes Cleared", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Updates the recipes list box with the current contents of AllRecipes.
        /// </summary>
        public void UpdateRecipesListBox()
        {
            // Clear the list box
            lstboxAllRecipes.Items.Clear();

            // Add recipes to the list box
            foreach (var recipe in AllRecipes)
            {
                lstboxAllRecipes.Items.Add(recipe);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)lstboxAllRecipes.SelectedItem;
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetToOriginal();
                UpdateRecipesListBox();
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.", "No Recipe Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
