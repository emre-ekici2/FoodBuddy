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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
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

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserView main = new NewUserView();
            main.Show();
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUser.Text;
            var password = txtPass.Password;

            using (DataContext context = new DataContext())
            {
                bool userFound = context.User.Any(user => user.Username == username && user.Password == password);

                if (userFound)
                {
                    GrantAccess();
                    Close();


                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.");
                }
                

            }
        }

        public void GrantAccess()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
