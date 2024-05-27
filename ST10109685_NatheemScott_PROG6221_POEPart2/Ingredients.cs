using System;

namespace NatheemScott_ST10109685_Prog6221_POE
{
    internal class Ingredients
    {
        /// <summary>
        /// Getters and setters for the Name, Quantity, Unit, Calories, FoodGroup, and Original Quantity. Also the constructor
        /// for all 6 variables.
        /// </summary>
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; } // Calories should be of type int
        public string FoodGroup { get; set; }
        public double OriginalQuantity { get; internal set; }

        public Ingredients(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories; // Assign the calories value
            FoodGroup = foodGroup;
            OriginalQuantity = quantity;
        }

        public Ingredients(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}