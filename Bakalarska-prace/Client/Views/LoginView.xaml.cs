using System.Windows;
using System.Windows.Controls;

namespace Bakalarska_prace.Views
{

    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Main.Content = new MainMenuView();
            }
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
