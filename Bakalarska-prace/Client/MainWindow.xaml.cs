using Bakalarska_prace.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bakalarska_prace { 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Main.Content = new LoginView();
        }
    }
}