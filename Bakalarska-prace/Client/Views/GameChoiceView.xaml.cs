using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Bakalarska_prace.Views
{
    /// <summary>
    /// Interakční logika pro gameChoose.xaml
    /// </summary>
    public partial class GameChoiceView : UserControl
    {
        public GameChoiceView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.Main.Content = new GameAgainstPcView();
            }
        }
    }
}


