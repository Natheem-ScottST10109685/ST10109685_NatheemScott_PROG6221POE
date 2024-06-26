using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POE
{
    public partial class pieChart : Window
    {
        public SeriesCollection PieChartData { get; set; }

        public pieChart(List<Recipe> selectedRecipes)
        {
            InitializeComponent();

            PieChartData = new SeriesCollection();
            CalculateFoodGroupPercentages(selectedRecipes);
            DataContext = this;
        }

        private void CalculateFoodGroupPercentages(List<Recipe> selectedRecipes)
        {
            var foodGroupCounts = new Dictionary<string, double>();

            foreach (var recipe in selectedRecipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (foodGroupCounts.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupCounts[ingredient.FoodGroup] += ingredient.Quantity;
                    }
                    else
                    {
                        foodGroupCounts[ingredient.FoodGroup] = ingredient.Quantity;
                    }
                }
            }

            double totalIngredients = foodGroupCounts.Values.Sum();
            foreach (var fg in foodGroupCounts)
            {
                PieChartData.Add(new PieSeries
                {
                    Title = fg.Key,
                    Values = new ChartValues<double> { (fg.Value / totalIngredients) * 100 },
                    DataLabels = true
                });
            }

            pieChartView.Series = PieChartData;
        }

        // Remove or adjust if needed
        private void btnPieChart_Click(object sender, RoutedEventArgs e)
        {
            // This event handler may not be needed if not used in your XAML
        }

        private void pieChartView_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            // Handle the ContextMenuClosing event here
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
