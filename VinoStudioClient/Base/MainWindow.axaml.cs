using Avalonia.Controls;
using VinoStudioClient.Base;

namespace VinoStudioClient.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}