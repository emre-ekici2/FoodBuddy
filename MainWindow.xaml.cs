using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace FoodBuddy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public int TotalCalories { get; set; }
        public int CalorieGoal { get; set; }

        public Double WeightLoss { get; set; }

        public int AverageEaten { get; set; }

        public int CaloriesRemaining { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            using (DataContext context = new DataContext())
            {
                var caloriesList = context.DailyFoodList.ToList();

                TotalCalories = caloriesList.Sum(x => x.Calories);



               


                var allCalories = context.DailyCalories.ToList();

                var last7Calories = allCalories.Skip(Math.Max(0, allCalories.Count() - 7)).Take(7);


                if (last7Calories.Any())
                {


                    var allWeights = context.Weight.ToList();

                    var last7Weights = allWeights.Skip(Math.Max(0, allWeights.Count() - 7)).Take(7);

                    var last7WeightAvg = last7Weights.Average(lwa => lwa.WeighIn);



                    var secondToLast7WeightsList = allWeights.Skip(Math.Max(0, allWeights.Count() - 14)).Take(7);

                    var secondToLast7WeightsAvg = secondToLast7WeightsList.Average(stlwa => stlwa.WeighIn);

                    var weightDifference = secondToLast7WeightsAvg - last7WeightAvg;





                    var last7CaloriesAvg = last7Calories.Average(lca => lca.Calories);

                    var dailyDeficit = (weightDifference * -1) * 1100;

                    var maintenanceCalories = last7CaloriesAvg - dailyDeficit;

                    CalorieGoal = (int)(maintenanceCalories - 550);

                    AverageEaten = (int)last7CaloriesAvg;

                    WeightLoss = Math.Round(weightDifference, 1) ;

                }

                CaloriesRemaining = CalorieGoal - TotalCalories;






            }

            this.DataContext = this;


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogWeight_Click(object sender, RoutedEventArgs e)
        {
            WeighinView main = new WeighinView();
            main.Show();
            Close();
        }

        private void btnCreateFood_Click(object sender, RoutedEventArgs e)
        {
            NewFoodView main = new NewFoodView();
            main.Show();
            Close();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {



            using (DataContext context = new DataContext())
            {
                var allWeights = context.Weight.ToList();

                var last7Weights = allWeights.Skip(Math.Max(0, allWeights.Count() - 7)).Take(7);

                var last7WeightAvg = last7Weights.Average(lwa => lwa.WeighIn);

                
                WeightList.ItemsSource = last7Weights;

                
                var secondToLast7WeightsList = allWeights.Skip(Math.Max(0, allWeights.Count() - 14)).Take(7);

                var secondToLast7WeightsAvg = secondToLast7WeightsList.Average(stlwa=> stlwa.WeighIn) ;

                var weightDifference = secondToLast7WeightsAvg - last7WeightAvg;



                var eatenFoods = context.DailyFoodList.ToList();

                EatenFoodList.ItemsSource = eatenFoods;



                var allCalories = context.DailyCalories.ToList();

                var last7Calories = allCalories.Skip(Math.Max(0, allCalories.Count() - 7)).Take(7);

                
            }


        }

        private void btnLogFood_Click(object sender, RoutedEventArgs e)
        {
            LogFoodView main = new LogFoodView();
            main.Show();
            Close();


        }

        
        private void btnLogCalories_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var caloriesList = context.DailyFoodList.ToList();

                int totalCalories = caloriesList.Sum(x => x.Calories);

                context.DailyCalories.Add(new DailyCalories() { Calories = totalCalories });
                context.DailyFoodList.RemoveRange(context.DailyFoodList);
                context.SaveChanges();

                

                MessageBox.Show("Calories logged!");

            }

            using (DataContext context = new DataContext())
            {
                var eatenFoods = context.DailyFoodList.ToList();

                EatenFoodList.ItemsSource = eatenFoods;


                var allCalories = context.DailyCalories.ToList();

                var last7Calories = allCalories.Skip(Math.Max(0, allCalories.Count() - 7)).Take(7);

                //CalorieList.ItemsSource = last7Calories;
                var caloriesList = context.DailyFoodList.ToList();

                TotalCalories = caloriesList.Sum(x => x.Calories);

                this.DataContext = this;


            }

            



        }

       

    }
}
