using Bakalarska_prace.Views;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Bakalarska_prace { 
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);

        const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;  // default value if not specifing a process ID

        // Somewhere in main method
        


        public MainWindow()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            InitializeComponent();
            Main.Content = new LoginView();
        }

     
    }
}