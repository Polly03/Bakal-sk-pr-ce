using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bakalarska_prace.Views
{
    /// <summary>
    /// Interakční logika pro GameAgainstPc.xaml
    /// </summary>
    public partial class GameAgainstPcView : UserControl
    {
        public GameAgainstPcView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Main.Content = new GameStartView();
            }
        }
    }
}
