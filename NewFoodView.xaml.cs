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
    /// Interaction logic for NewFoodView.xaml
    /// </summary>
    public partial class NewFoodView : Window
    {
        public NewFoodView()
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

        private void btnCreateFood_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var inputFoodName = txtFoodName.Text;
                var inputCalories = int.Parse(txtCalories.Text);
                var inputServingSize = int.Parse(txtServingSize.Text);
                var inputServingType = txtServingType.Text;
                var inputProtein = int.Parse(txtProtein.Text);
                var inputCarbohydrate = int.Parse(txtCarbohydrate.Text);
                var inputFat = int.Parse(txtFat.Text);

                if (inputFoodName != null && inputServingType != null)
                {
                    context.Food.Add(new Food() { Foodname= inputFoodName, Calories = inputCalories, ServingSize = inputServingSize, ServingType = inputServingType, Protein = inputProtein, Carbohydrate = inputCarbohydrate, Fat = inputFat});
                    context.SaveChanges();
                    MessageBox.Show("New food item created");
                    MainWindow main = new MainWindow();
                    main.Show();
                    Close();
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
