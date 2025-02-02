using CommunityToolkit.Mvvm.ComponentModel;
using VinoStudioClient.General.Navigation;
using VinoStudioClient.General.Section;

namespace VinoStudioClient.Base
{
    internal partial class MainWindowViewModel : ViewModelBase    
    {
        [ObservableProperty]
        private NavigationViewModel navigationViewModel = new();

        [ObservableProperty]
        private SectionViewModel sectionViewModel = new();
    }
}
