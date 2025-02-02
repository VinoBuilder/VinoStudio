using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.General.Navigation;

namespace VinoStudioClient.Base
{
    internal partial class MainWindowViewModel : ViewModelBase    
    {
        [ObservableProperty]
        private NavigationViewModel navigationViewModel = new();
    }
}
