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
    /// Interaction logic for WeighinView.xaml
    /// </summary>
    public partial class WeighinView : Window
    {
        public WeighinView()
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

        
        private void btnLogWeight_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var inputWeight = double.Parse(txtUserWeight.Text);
                
                if (inputWeight != 0)
                {
                    context.Weight.Add(new Weight() { WeighIn = inputWeight });
                    context.SaveChanges();
                    MessageBox.Show("Weight recorded!");
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
