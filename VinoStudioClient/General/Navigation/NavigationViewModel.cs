using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VinoStudioClient.Base;

namespace VinoStudioClient.General.Navigation
{
    public partial class NavigationViewModel : ViewModelBase
    {
        public ObservableCollection<string> Sections { get; private set; } = [
            "Layout"
        ];

        [ObservableProperty]
        private string selectedSection = "";
    }
}
