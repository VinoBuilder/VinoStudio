using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VinoStudioClient.Base;
using VinoStudioClient.Sections.Layout;

namespace VinoStudioClient.General.Navigation
{
    public partial class NavigationViewModel : ViewModelBase
    {
        public ObservableCollection<NavigationItemViewModel> Sections { get; private set; }

        [ObservableProperty]
        private NavigationItemViewModel? selectedSection;

        public NavigationViewModel()
        {
            Sections = [new NavigationItemViewModel("Layout", new LayoutSectionViewModel())];
            SelectedSection = Sections.FirstOrDefault(); // Select first by default
        }
    }

}
