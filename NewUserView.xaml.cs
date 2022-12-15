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
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class NewUserView : Window
    {
        public NewUserView()
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

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            LoginView main = new LoginView();
            main.Show();
            Close();
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var inputUsername = txtUser.Text;
                var inputPassword = txtPass.Password;
                var inputWeight = double.Parse(txtUserWeight.Text);

                if (inputUsername != null && inputPassword != null )
                {
                    context.User.Add(new User() { Username = inputUsername, Password = inputPassword});
                    context.SaveChanges();
                    context.Weight.Add(new Weight() { WeighIn = inputWeight });
                    context.SaveChanges();
                    MessageBox.Show("New user created");
                    LoginView main = new LoginView();
                    main.Show();
                    Close();
                }

            }
        }
    }
}
