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
using System.Windows.Shapes;

namespace FoodBuddy
{

    /// <summary>
    /// Interaction logic for LogFoodView.xaml
    /// </summary>
    public partial class LogFoodView : Window
    {
        public int TotalCalories { get; set; }

        public LogFoodView()
        {
            InitializeComponent();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var allFoods = context.Food.ToList();

                FoodList.ItemsSource = allFoods;
                      



                

            }
        }

        private void btnLogFood_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                Food selectedFood = FoodList.SelectedItem as Food;
                Food food = context.Food.Single(x => x.Id == selectedFood.Id);

                var selectedFoodName = food.Foodname;
                var selectedCalories = food.Calories;
                var selectedServingSize = food.ServingSize;
                var selectedServingType = food.ServingType;
                var selectedProtein = food.Protein;
                var selectedCarbohydrate = food.Carbohydrate;
                var selectedFat = food.Fat;

                if (selectedFood != null)
                {

                    context.DailyFoodList.Add(new DailyFoodList() { Foodname = selectedFoodName, Calories = selectedCalories, ServingSize = selectedServingSize, ServingType = selectedServingType, Protein = selectedProtein, Carbohydrate = selectedCarbohydrate, Fat = selectedFat });
                    context.SaveChanges();


                    MessageBox.Show("Food entry successful!");


                }

            }

        }
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
